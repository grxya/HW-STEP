using HW.Models;
using HW.Models.Interfaces;

namespace HW.Services.Interfaces;

public interface IService
{
    public Task<IModel> GetData(string info);
}
