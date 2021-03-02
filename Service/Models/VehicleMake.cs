using Service.Interfaces;

namespace Service.Models
{
    public class VehicleMake : IVehicleMake
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}