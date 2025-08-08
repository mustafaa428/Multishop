using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BussinesLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrate;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var values = _cargoCustomerService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {

            var value = _cargoCustomerService.TGetById(id);
            return Ok(value);

        }


        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Address = createCargoCustomerDto.Address,
                City = createCargoCustomerDto.City,
                District = createCargoCustomerDto.District,
                Email = createCargoCustomerDto.Email,
                Name = createCargoCustomerDto.Name,
                Phone = createCargoCustomerDto.Phone,
                Surname = createCargoCustomerDto.Surname,
                UserCustomerId = createCargoCustomerDto.UserCustomerId,
            };
            _cargoCustomerService.TInsert(cargoCustomer);
            return Ok("Karg müşteri ekleme işlemi başarıyla yapıldı");
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDtos updateCargoCustomerDtos)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                CargoCustomerId = updateCargoCustomerDtos.CargoCustomerId,
                Address = updateCargoCustomerDtos.Address,
                City = updateCargoCustomerDtos.City,
                District = updateCargoCustomerDtos.District,
                Email = updateCargoCustomerDtos.Email,
                Name = updateCargoCustomerDtos.Name,
                Phone = updateCargoCustomerDtos.Phone,
                Surname = updateCargoCustomerDtos.Surname,
                UserCustomerId = updateCargoCustomerDtos.UserCustomerId
            };
            _cargoCustomerService.TUpdate(cargoCustomer);
            return Ok("Kargo müşteri güncelleme işlemi başarıyla yapıldı");
        }

        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Kargo müşteri silme işlemi başarıyla yapıldı");
        }

        [HttpGet("GetCargoCustomerByUserId/{id}")]
        public IActionResult GetCargoCustomerByUserId(string id)
        {
            var result = _cargoCustomerService.TGetCustomerByID(id);
            return Ok(result);
        }

    }
}
