using System.Collections.Generic;
using System.Threading.Tasks;
using API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
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
        public async Task<ActionResult<VehicleMake>> CreateVehicleMake(VehicleMakeDto vehicleMakeDto)
        {
            if (vehicleMakeDto == null) return BadRequest();

            var vehicleMake = _mapper.Map<VehicleMake>(vehicleMakeDto);

            _unitOfWork.VehicleService.CreateVehicleMakeAsync(vehicleMake);

            if (await _unitOfWork.Complete()) return Ok(vehicleMake);

            return BadRequest("Failed creating given Vehicle Make!");
        }

        
        [HttpPost]
        public async Task<ActionResult<VehicleModel>> CreateVehicleModel(VehicleModelDto vehicleModelDto)
        {
            if (vehicleModelDto == null) return BadRequest();

            var vehicleModel = _mapper.Map<VehicleModel>(vehicleModelDto);

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
        public async Task<ActionResult> UpdateVehicleMake(VehicleMakeDto vehicleMakeDto)
        {
            var make = await _unitOfWork.VehicleService.GetVehicleMakeByNameAsync(vehicleMakeDto.Name);

            _mapper.Map(vehicleMakeDto, make);

            _unitOfWork.VehicleService.Update(make);

            if (await _unitOfWork.Complete()) return NoContent();

            return BadRequest("Failed to update Vehicle Make!");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateVehicleModel(VehicleModelDto vehicleModelDto)
        {
            var model = await _unitOfWork.VehicleService.GetVehicleModelByNameAsync(vehicleModelDto.Name);

            _mapper.Map(vehicleModelDto, model);

            _unitOfWork.VehicleService.Update(model);

            if (await _unitOfWork.Complete()) return NoContent();

            return BadRequest("Failed to update Vehicle Model!");
        }
    }
}