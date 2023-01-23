using HackerDataTest.Models;

namespace HackerDataTest.Services
{
    public interface IItemService
    {
        Task<List<Item>> GetHackerData(int id);
    }
}
