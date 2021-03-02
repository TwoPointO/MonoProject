using Service.Interfaces;

namespace Service.Models
{
    public class VehicleModel : IVehicleModel
    {
        public int Id { get; set; }
        public int MakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}