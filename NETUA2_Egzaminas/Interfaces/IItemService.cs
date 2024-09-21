using Microsoft.Extensions.Primitives;
using NETUA2_Egzaminas.API.DTOs;
using NETUA2_Egzaminas.DAL.Entities;

namespace NETUA2_Egzaminas.API.Interfaces
{
    public interface IItemService
    {
        Item GetItemById(int id);
        void AddItem(string name, string description, int value);
        List<Item> GetAll();
    }
}
