import configparser
import requests
from bs4 import BeautifulSoup
import json
from flask import Flask

# Reading creds and settings
config = configparser.ConfigParser()
config.read('settings.ini')

app = Flask(__name__)

@app.route("/")
def api_request():

    # Getting the content of the login page for CSRF token
    content_of_loginpage = requests.get(config['URLs']['LoginPage'])
    soup = BeautifulSoup(content_of_loginpage.content, "html.parser")

    # For reference, just in case:
    # <input type="hidden" name="CSRFToken" value="cb3875a6-bb78-4e52-950f-77c7eb6bd543" />
    results = soup.find_all("input", {"name":"CSRFToken"})
    CSRFToken = results[0].get('value')

    # Sending login request
    data = {"j_username": config['Credentials']['Username'], "j_password": config['Credentials']['Password'], "CSRFToken": CSRFToken}
    headers = {'Content-Type': 'application/x-www-form-urlencoded'}
    result_after_login = requests.post(config['URLs']['SecurityPage'], data=data, headers=headers)

    # Hunting down data which I'm interested in
    soup = BeautifulSoup(result_after_login.content, "html.parser")
    awards_amount = soup.find_all("span", {"class":"amount"})
    awards_currency = soup.find_all("span", {"class":"currency"})
    awards_stars = soup.find_all("div", {"class":"starsCountMain"})

    # Labeling it
    output_object = {
        "currentAmount": awards_amount[0].text,
        "currency": awards_currency[0].text,
        "currentStars": awards_stars[0].text
    }

    # Boxing it up, aaaand shipping!
    return json.dumps(output_object)