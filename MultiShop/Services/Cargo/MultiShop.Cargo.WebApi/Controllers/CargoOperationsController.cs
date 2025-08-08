using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BussinesLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationsDtos;
using MultiShop.Cargo.EntityLayer.Concrate;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationsController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }

        [HttpGet]
        public IActionResult CargoOperationsList()
        {
            var values = _cargoOperationService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoOperationsById(int id)
        {
            var value = _cargoOperationService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoOptions(CreateCargoOperationsDto createCargoOperationsDto)
        {
            CargoOperations cargoOperations = new CargoOperations()
            {
                Barcode = createCargoOperationsDto.Barcode,
                Description = createCargoOperationsDto.Description,
                OperationDate = createCargoOperationsDto.OperationDate,
            };

            _cargoOperationService.TInsert(cargoOperations);
            return Ok("Kargo hareketleri oluşturuldu.");
        }

        [HttpPut]
        public IActionResult UpdateCargoOperations(UpdateCargoOperationsDto updateCargoOperationsDto)
        {
            CargoOperations cargoOperations = new CargoOperations()
            {
                Barcode = updateCargoOperationsDto.Barcode,
                Description = updateCargoOperationsDto.Description,
                CargoOperationId = updateCargoOperationsDto.CargoOperationId,
                OperationDate = updateCargoOperationsDto.OperationDate
            };

            _cargoOperationService.TUpdate(cargoOperations);
            return Ok("Kargo hareketi güncellendi.");
        }

        [HttpDelete]
        public IActionResult RemoveCargoOperations(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Kargo hareketi silindi.");
        }
    }
}
