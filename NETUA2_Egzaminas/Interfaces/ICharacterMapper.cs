using NETUA2_Egzaminas.API.DTOs;
using NETUA2_Egzaminas.DAL.Entities;

namespace NETUA2_Egzaminas.API.Interfaces
{
    public interface ICharacterMapper
    {
        public Character CharacterMapping(PostCreateCharacterDTO dto);
        public Character UpdateCharacterMapping(PostCreateCharacterDTO dto, Character existingChar);

    }
}
