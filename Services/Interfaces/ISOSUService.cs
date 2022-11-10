global using Entities;
global using System.Collections.ObjectModel;

namespace Services.Interfaces
{
    public interface ISOSUService<TEntity> where TEntity : class
    {
        Task<List<TEntity>> DoHttpGetRequest(string controllerUrl);
        Task<string> DoHttpPostRequest(string controllerUrl, TEntity entityToInsert);
        Task<string> DoHttpPutRequest(string controllerUrl, TEntity entityToUpdate);
    }
}