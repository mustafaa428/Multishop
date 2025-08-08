using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommand updateAddressCommand)
        {
            var values = await _repository.GetByIdAsync(updateAddressCommand.AddressId);
            values.Surname = updateAddressCommand.Surname;
            values.City = updateAddressCommand.City;
            values.Discrit = updateAddressCommand.Discrit;
            values.Detail1 = updateAddressCommand.Detail1;
            values.Detail2 = updateAddressCommand.Detail2;
            values.Country = updateAddressCommand.Country;
            values.Phone = updateAddressCommand.Phone;
            values.Description = updateAddressCommand.Description;
            values.Email = updateAddressCommand.Email;
            values.ZipCode = updateAddressCommand.ZipCode;
            values.UserId = updateAddressCommand.UserId;
            values.Name = updateAddressCommand.Name;
            await _repository.UpdateAsync(values);
        }
    }
}
