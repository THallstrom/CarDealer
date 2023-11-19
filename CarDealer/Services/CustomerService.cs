using CarDealer.Entitys;
using CarDealer.Models;
using CarDealer.Repositorys;

namespace CarDealer.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepository;
        private readonly AddressRepository _addressRepository;

        public CustomerService(CustomerRepository customerRepoitory, AddressRepository addressRepository)
        {
            _customerRepository = customerRepoitory;
            _addressRepository = addressRepository;
        }

        public async Task<CustomerEntity> CreateCustomerAsync(CustomerRegistrationForm form)
        {
            if (!await _customerRepository.ExistAsync(x => x.Email == form.Email))
            {
                var address = await _addressRepository.GetAsync(x => x.StreetName == form.StreetAddress && x.PostalCode == form.PostalCode);
                address ??= await _addressRepository.CreateAsync(new AddressEntity
                {
                    StreetName = form.StreetAddress,
                    PostalCode = form.PostalCode,
                    City = form.City,
                });
                var customer = await _customerRepository.CreateAsync(new CustomerEntity
                {
                    FirstName = form.FirstName,
                    LastName = form.LastName,
                    Email = form.Email,
                    Phone = form.Phone,
                    Address = address!
                });
                return customer;
            }
            return null!;
        }

        public async Task<IEnumerable<CustomerEntity>> ReadAllCustomerAsync()
        {
            var customer = await _customerRepository.GetAllAsync();
            return customer ?? null!;
        }

        public async Task<CustomerEntity> UpdateAsync(CustomerUpdateForm form)
        {
            var entity = await _customerRepository.GetAsync(x => x.FirstName == form.FirstName && x.LastName == form.LastName);
            if (entity != null)
            {
                var address = await _addressRepository.GetAsync(x => x.Id == entity.AddressId);
                if (address != null)
                {
                    if (form.PostalCode != string.Empty)
                        address.PostalCode = form.PostalCode!;
                    if (form.StreetName != string.Empty)
                        address.StreetName = form.StreetName!;
                    if (form.City != string.Empty)
                        address.City = form.City!;
                    entity.Address = address;
                }
                if (form.Phone != string.Empty)
                    entity.Phone = form.Phone!;
                if (form.Email != string.Empty)
                    entity.Email = form.Email!;
                return await _customerRepository.UpdateAsync(entity);
            }
            return null!;
        }
    }
}
