using NETUA2_Egzaminas.API.DTOs;
using NETUA2_Egzaminas.DAL.Entities;

namespace NETUA2_Egzaminas.API.Interfaces
{
    public interface IItemService
    {
        Item GetItemById(int id);
        Item GetItemByUserId(int userId); 
        List<Item> GetAll();
    }
}
