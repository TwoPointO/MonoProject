using System.Collections.Generic;
using System.Threading.Tasks;
using API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.Extensions;
using Service.Interfaces;
using Service.Models;

namespace Service.Controllers
{
    public class VehicleController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public VehicleController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        public async Task<ActionResult<PagedList<VehicleMake>>> GetVehicleMakes([FromQuery] PaginationParams paginationParams)
        {
            var makes = await _unitOfWork.VehicleService.GetVehicleMakesAsync(paginationParams);

            Response.AddPaginationHeader(makes.CurrentPage,
            makes.PageSize, makes.TotalCount, makes.TotalPages);

            return makes;
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<VehicleModel>>> GetVehicleModels([FromQuery] PaginationParams paginationParams)
        {
            var models = await _unitOfWork.VehicleService.GetVehicleModelsAsync(paginationParams);

            Response.AddPaginationHeader(models.CurrentPage,
            models.PageSize, models.TotalCount, models.TotalPages);

            return models;
        }

        [HttpPost]
        public async Task<ActionResult<VehicleMake>> CreateVehicleMake(VehicleMake vehicleMake)
        {
            if (vehicleMake == null) return BadRequest();

            _unitOfWork.VehicleService.CreateVehicleMakeAsync(vehicleMake);

            if (await _unitOfWork.Complete()) return Ok(vehicleMake);

            return BadRequest("Failed creating given Vehicle Make!");
        }

        
        [HttpPost]
        public async Task<ActionResult<VehicleModel>> CreateVehicleModel(VehicleModel vehicleModel)
        {
            if (vehicleModel == null) return BadRequest();

            _unitOfWork.VehicleService.CreateVehicleModelAsync(vehicleModel);

            if (await _unitOfWork.Complete()) return Ok(vehicleModel);

            return BadRequest("Failed creating given Vehicle Model!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVehicleMake(int id)
        {
            var make = await _unitOfWork.VehicleService.GetVehicleMakeByIdAsync(id);
            _unitOfWork.VehicleService.DeleteVehicleMakeAsync(make);
            if (await _unitOfWork.Complete()) return Ok();
            return BadRequest("Problem removing the given Vehicle Make!");
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVehicleModel(int id)
        {
            var model = await _unitOfWork.VehicleService.GetVehicleModelByIdAsync(id);
            _unitOfWork.VehicleService.DeleteVehicleModelAsync(model);
            if (await _unitOfWork.Complete()) return Ok();
            return BadRequest("Problem removing the given Vehicle Model!");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateVehicleMake(VehicleMake vehicleMake)
        {
            var make = await _unitOfWork.VehicleService.GetVehicleMakeByNameAsync(vehicleMake.Name);

            //_mapper.Map(vehicleMakeUpdateDto, make);

            _unitOfWork.VehicleService.Update(make);

            if (await _unitOfWork.Complete()) return NoContent();

            return BadRequest("Failed to update Vehicle Make!");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateVehicleModel(VehicleModel vehicleModel)
        {
            var model = await _unitOfWork.VehicleService.GetVehicleModelByNameAsync(vehicleModel.Name);

            //_mapper.Map(vehicleModelUpdateDto, model);

            _unitOfWork.VehicleService.Update(model);

            if (await _unitOfWork.Complete()) return NoContent();

            return BadRequest("Failed to update Vehicle Model!");
        }
    }
}