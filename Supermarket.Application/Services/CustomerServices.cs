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
        private readonly IMemberShipTypeRepository _memberShipTypeRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CustomerServices(ICustomerRepository customerRepository,IMemberShipTypeRepository memberShipTypeRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _memberShipTypeRepository = memberShipTypeRepository;
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
            var result = await _customerRepository.GetSingleByConditionAsync(x=>x.Id == id&&x.IsDelete==false,IncludeConstants.CustomerIncludes);
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

        public async Task<IEnumerable<CustomerResponseDto>> getPagingAsync(int index, int size)
        {
            var result = await _customerRepository.GetMultiPagingAsync(x => x.IsDelete == false, index, size,IncludeConstants.CustomerIncludes);
            //foreach (var customer in result)
            //{
            //    var resultMemberShip = await _memberShipTypeRepository.GetSingleByIdAsync(customer.MembershipTypeId);
            //    if (resultMemberShip != null)
            //    {
            //        customer.MembershipType = resultMemberShip;
            //    }
            //}
            var resultMap = _mapper.Map<IEnumerable<CustomerResponseDto>>(result);
            return resultMap;
        }

        public async Task<int> getTotalPagingTask(int size)
        {
            var result = await _customerRepository.CountAsync(x => x.IsDelete == false);
            decimal total = Math.Ceiling((decimal)result / size);
            return (int)total;
        }
       
    }
}
