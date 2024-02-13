namespace NETUA2_Egzaminas.API.DTOs
{
    public class UpdateUserResidenceDTO
    {
        public string Town { get; set; }
        public string Street { get; set; }
        /// <summary>
        /// This prop is string because sometimes houses are divided in subplaces like 29A 29B 29C etc
        /// </summary>
        public string BuildingNumber { get; set; }
        public string FlatNumber { get; set; }
    }
}
