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

        public async Task <CustomerEntity> CreateCustomerAsync(CustomerRegistrationForm form)
        {
            if(!await _customerRepository.ExistAsync(x => x.Email == form.Email))
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

        public async Task <IEnumerable<CustomerEntity>> ReadAllCustomerAsync()
        {
            var customer = await _customerRepository.GetAllAsync();
            return customer ?? null!;            
        }                       
    }
}
