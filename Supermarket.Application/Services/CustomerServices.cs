using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.IRepositories;
using Supermarket.Application.IServices;
using Supermarket.Application.UnitOfWork;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Application.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CustomerServices(ICustomerRepository customerRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CustomerResponseDto>> GetAllAsync()
        {
            var result = await _customerRepository.GetAllAsync();
            var resultMap = _mapper.Map<ICollection<CustomerResponseDto>>(result);
            return resultMap;
        }

        public async Task<CustomerResponseDto> GetByIdAsync(Guid id)
        {
            var result = await _customerRepository.GetSingleByIdAsync(id);
            var resultMap = _mapper.Map<CustomerResponseDto>(result);
            return resultMap;
        }

        public async Task<bool> CreateAsync(CustomerRequestDto entity, Guid userId)
        {
            if (entity == null)
                return false;
            var entityMap = _mapper.Map<Customer>(entity);
            var result = await _customerRepository.AddAsync(entityMap, userId);
            if (result == null)
                return false;
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(CustomerRequestDto entity, Guid id, Guid userId)
        {
            if (entity == null)
                return false;
            var CustomerValue = _mapper.Map<Customer>(entity);
            var entityType = "Customer";
            var result = await _customerRepository.UpdateAsync(CustomerValue, id, entityType, userId);
            if (result == null)
                return false;
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id, Guid userId)
        {
            var result = await _customerRepository.DeleteAsync(id, userId);
            if (result == null)
                return false;
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
