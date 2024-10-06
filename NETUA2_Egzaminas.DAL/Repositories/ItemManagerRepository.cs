using NETUA2_Egzaminas.DAL.Entities;
using NETUA2_Egzaminas.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETUA2_Egzaminas.DAL.Repositories
{
    public class ItemManagerRepository : IItemManagerRepository
    {
        private readonly AppDbContext _context;

        public ItemManagerRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddItem(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }

        public Item GetItemById(int id)
        {
            return _context.Items.SingleOrDefault(i => i.ItemId == id); ;
        }

        public List<Item> GetAll()
        {
            return _context.Items.ToList();
        }

        public void RemoveItem(Item item)
        {

        }

		public void RemoveItemById(int id)
		{

		}
		public int GetItemCount()
        {
            return _context.Items.Count();
        }
    }
}
