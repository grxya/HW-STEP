using CurrencyByCity.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyByCity.Services.Interfaces;

public interface IService
{
    public Task<IModel> GetData(string info);
}
