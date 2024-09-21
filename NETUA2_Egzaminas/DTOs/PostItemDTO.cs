using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NETUA2_Egzaminas.API.DTOs
{
    public class PostItemDTO
    {
        public string ImgId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public JsonAttribute Stats { get; set; }
    }
}
