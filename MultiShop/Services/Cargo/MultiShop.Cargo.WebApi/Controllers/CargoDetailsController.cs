using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BussinesLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrate;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _cargoDetailService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var value = _cargoDetailService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto cargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                BarCode = cargoDetailDto.BarCode,
                CargoCompanyId = cargoDetailDto.CargoCompanyId,
                ReceiverCustomer = cargoDetailDto.ReceiverCustomer,
                SenderCustomer = cargoDetailDto.ReceiverCustomer,
            };

            _cargoDetailService.TInsert(cargoDetail);
            return Ok("Kargo detayı başarıyla eklendi");
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto cargoDetailDto)
        {
            CargoDetail CargoDetail = new CargoDetail()
            {
                CargoCompanyId = cargoDetailDto.CargoCompanyId,
                BarCode = cargoDetailDto.BarCode,
                CargoDetailId = cargoDetailDto.CargoDetailId,
                ReceiverCustomer = cargoDetailDto.ReceiverCustomer,
                SenderCustomer = cargoDetailDto.SenderCustomer
            };
            _cargoDetailService.TUpdate(CargoDetail);
            return Ok("Kargo detayları başarıyla güncellendi.");
        }

        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Kargo detayı silindi");
        }
    }
}
