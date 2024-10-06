using NETUA2_Egzaminas.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETUA2_Egzaminas.DAL.Interfaces
{
    public interface IItemManagerRepository
    {
        void AddItem(Item item);
        void RemoveItem(Item item);
        void RemoveItemById(int id);
        Item GetItemById(int id);
        List<Item> GetAll();
        int GetItemCount();
    }
}
