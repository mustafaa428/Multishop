using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetAddressByIdQueryResult
            {
                Name = values.Name,
                UserId = values.UserId,
                ZipCode = values.ZipCode,
                City = values.City,
                Email = values.Email,
                Description = values.Description,
                Phone = values.Phone,
                Country = values.Country,
                Detail2 = values.Detail2,
                AddressId = values.AddressId,
                Detail1 = values.Detail1,
                Discrit = values.Discrit,
                Surname = values.Surname
            };
        }
    }
}
