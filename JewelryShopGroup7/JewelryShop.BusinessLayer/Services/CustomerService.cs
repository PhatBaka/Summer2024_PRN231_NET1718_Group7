using AutoMapper;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Customer;

namespace JewelryShop.BusinessLayer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(CreateCustomerRequest createModel)
        {
            Customer customer = _mapper.Map<Customer>(createModel);
            return await _customerRepository.AddAsync(customer);
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var customer = (await _customerRepository.GetAsync(c => c.CustomerId == id)).FirstOrDefault();
                if (customer != null)
                {
                    await _customerRepository.RemoveAsync(customer);
                }
                else
                {
                    throw new KeyNotFoundException("Customer not found.");
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<CustomerResponse>> GetAllAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerResponse>>(customers.ToList());
        }

        public async Task<CustomerResponse> GetByIdAsync(Guid id)
        {
            var customer = (await _customerRepository.GetAsync(c => c.CustomerId == id)).FirstOrDefault();
            return _mapper.Map<CustomerResponse>(customer);
        }

        public async Task UpdateAsync(Guid id, UpdateCustomerRequest updateModel)
        {
            var customer = (await _customerRepository.GetAsync(c => c.CustomerId == id)).FirstOrDefault();
            if (customer != null)
            {
                var updateCustomer = _mapper.Map(updateModel, customer);
                await _customerRepository.UpdateAsync(updateCustomer);
            }
            else
            {
                throw new KeyNotFoundException("Customer not found.");
            }
        }
    }
}
