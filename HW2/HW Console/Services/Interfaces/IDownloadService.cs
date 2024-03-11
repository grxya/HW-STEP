namespace HW.Services.Interfaces;

public interface IDownloadService
{
    public Task<string> GetJson(HttpRequestMessage request);
}