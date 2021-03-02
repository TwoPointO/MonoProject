using System.Collections.Generic;
using System.Threading.Tasks;
using API.Helpers;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Service.Data;
using Service.Interfaces;

namespace Service.Models
{
    public class VehicleService : IVehicleService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public VehicleService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Update(VehicleMake vehicleMake) { 
            _context.Entry(vehicleMake).State = EntityState.Modified;
        }
        public void Update(VehicleModel vehicleModel) { 
            _context.Entry(vehicleModel).State = EntityState.Modified;
        }
        public void CreateVehicleMakeAsync(VehicleMake vehicleMake) { }
        public void CreateVehicleModelAsync(VehicleModel vehicleModel) { }
        public void DeleteVehicleModelAsync(VehicleModel vehicleModel) { }
        public void DeleteVehicleMakeAsync(VehicleMake vehicleMake) { }
        public async Task<IEnumerable<VehicleMake>> GetVehicleMakesAsync() {
            return await _context.VehicleMake.ToListAsync();
         }
        public async Task<VehicleMake> GetVehicleMakeByIdAsync(int id) { 
            return await _context.VehicleMake.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<VehicleMake> GetVehicleMakeByNameAsync(string name) {
            return await _context.VehicleMake.FirstOrDefaultAsync(x => x.Name == name);
         }
        public async Task<PagedList<VehicleMake>> GetVehicleMakesAsync(PaginationParams paginationParams) { 
            var query = _context.VehicleMake.AsQueryable();
            return await PagedList<VehicleMake>.CreateAsync(query, paginationParams.PageNumber, paginationParams.PageSize);
        }
        public async Task<IEnumerable<VehicleModel>> GetVehicleModelsAsync() { 
            return await _context.VehicleModel.ToListAsync();
        }
        public async Task<VehicleModel> GetVehicleModelByIdAsync(int id) { 
            return await _context.VehicleModel.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<VehicleModel> GetVehicleModelByNameAsync(string name) {
            return await _context.VehicleModel.FirstOrDefaultAsync(x => x.Name == name);
         }
        public async Task<PagedList<VehicleModel>> GetVehicleModelsAsync(PaginationParams paginationParams) {
            var query = _context.VehicleModel.AsQueryable();
            return await PagedList<VehicleModel>.CreateAsync(query, paginationParams.PageNumber, paginationParams.PageSize);
         }

    }
}