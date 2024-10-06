using Microsoft.Extensions.Primitives;
using NETUA2_Egzaminas.API.DTOs;
using NETUA2_Egzaminas.DAL.Entities;

namespace NETUA2_Egzaminas.API.Interfaces
{
    public interface IItemService
    {
        Item GetItemById(int id);
        void AddItem(Item item);
        List<Item> GetAll();
		bool GetItemByName(string name);
        int GetItemsCount();
	}
}
