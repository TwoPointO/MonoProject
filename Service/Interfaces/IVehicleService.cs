using System.Collections.Generic;
using System.Threading.Tasks;
using API.Helpers;
using Service.Models;

namespace Service.Interfaces
{
    public interface IVehicleService
    {
        void Update(VehicleMake vehicleMake);
        void Update(VehicleModel vehicleModel);
        void CreateVehicleMakeAsync(VehicleMake vehicleMake);
        void CreateVehicleModelAsync(VehicleModel vehicleModel);
        void DeleteVehicleModelAsync(VehicleModel vehicleModel);
        void DeleteVehicleMakeAsync(VehicleMake vehicleMake);
        Task<IEnumerable<VehicleMake>> GetVehicleMakesAsync();
        Task<VehicleMake> GetVehicleMakeByIdAsync(int id);
        Task<VehicleMake> GetVehicleMakeByNameAsync(string name);
        Task<PagedList<VehicleMake>> GetVehicleMakesAsync(PaginationParams paginationParams);
        Task<IEnumerable<VehicleModel>> GetVehicleModelsAsync();
        Task<VehicleModel> GetVehicleModelByIdAsync(int id);
        Task<VehicleModel> GetVehicleModelByNameAsync(string name);
        Task<PagedList<VehicleModel>> GetVehicleModelsAsync(PaginationParams paginationParams);
    }
}