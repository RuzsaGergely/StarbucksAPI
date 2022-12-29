using StarbucksBalance.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VizoraApp.Data
{
    public interface IRestService
    {
        Task<StarbucksData> GetStarbucksData();
    }
}
