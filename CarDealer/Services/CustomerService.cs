using CarDealer.Entitys;
using CarDealer.Repositorys;

namespace CarDealer.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepoitory;
        private readonly AddressRepository _addressRepository;

        public CustomerService(CustomerRepository customerRepoitory, AddressRepository addressRepository)
        {
            _customerRepoitory = customerRepoitory;
            _addressRepository = addressRepository;
        }
    }
}
