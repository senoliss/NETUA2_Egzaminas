using NETUA2_Egzaminas.API.DTOs;
using NETUA2_Egzaminas.API.Interfaces;
using NETUA2_Egzaminas.DAL.Entities;

namespace NETUA2_Egzaminas.API.Mappers
{
    public class ItemMapper : IItemMapper
	{
		public Item ItemMapping(PostItemDTO dto)
		{
			var item = new Item
			{
				ImgId = dto.ImgId,
				Name = dto.Name,
				Type = dto.Type,
				Description = dto.Description,
				Value = dto.Value,
				Stackable = dto.Stackable,
				Count = dto.Count,
				Level = dto.Level,
				Defense = dto.Defense,
				Attack = dto.Attack,
				Durability = dto.Durability
			};

			return item;
		}
	}
}
