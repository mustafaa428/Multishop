using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAddressQueryResult>> Handler()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAddressQueryResult
            {
                Name = x.Name,
                UserId = x.UserId,
                ZipCode = x.ZipCode,
                City = x.City,
                Email = x.Email,
                Description = x.Description,
                Phone = x.Phone,
                Country = x.Country,
                Detail2 = x.Detail2,
                AddressId = x.AddressId,
                Detail1 = x.Detail1,
                Discrit = x.Discrit,
                Surname = x.Surname
            }).ToList();
        }
    }
}
