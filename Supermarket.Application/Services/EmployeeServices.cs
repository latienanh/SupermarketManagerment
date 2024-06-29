using AutoMapper;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.IRepositories;
using Supermarket.Application.IServices;
using Supermarket.Application.UnitOfWork;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Application.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeServices(IMapper mapper, IUnitOfWork unitOfWork, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _employeeRepository = employeeRepository;
        }
        public async Task<IEnumerable<EmployeeResponseDto>> GetAllAsync()
        {
            var result = await _employeeRepository.GetMultiAsync(x => x.IsDelete == false);
            if (result != null)
            {
                var resultMap = _mapper.Map<IEnumerable<EmployeeResponseDto>>(result);
                return resultMap;
            }

            return null;

        }

        public async Task<EmployeeResponseDto> GetByIdAsync(Guid id)
        {
            var result = await _employeeRepository.GetSingleByIdAsync(id);
            var resultMap = _mapper.Map<EmployeeResponseDto>(result);
            return resultMap;
        }

        public async Task<bool> CreateAsync(EmployeeRequestDto entity, Guid userId)
        {
            if (entity == null)
                return false;
            var employee = _mapper.Map<Employee>(entity);

            employee.Image = entity.PathImage;
            var result = await _employeeRepository.AddAsync(employee, userId);
            if (result == null)
                return false;
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(EmployeeRequestDto entity, Guid id, Guid userId)
        {
            if (entity == null)
                return false;
            var employeeUpdate = _mapper.Map<Employee>(entity);
            if (entity.PathImage != null)
            {
                employeeUpdate.Image = entity.PathImage;
            }
            var entityType = "Employee";
            var result = await _employeeRepository.updateEmployee(employeeUpdate, id, entityType, userId);
            if (result == null)
                return false;
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id, Guid userId)
        {
            var result = await _employeeRepository.DeleteAsync(id, userId);
            if (result == null)
                return false;
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<IEnumerable<EmployeeResponseDto>> getPagingAsync(int index, int size)
        {
            var result = await _employeeRepository.GetMultiPagingAsync(x => x.IsDelete == false, index, size);
            var resultMap = _mapper.Map<IEnumerable<EmployeeResponseDto>>(result);
            return resultMap;
        }

        public async Task<int> getTotalPagingTask(int size)
        {
            var result = await _employeeRepository.CountAsync(x => x.IsDelete == false);
            decimal total = Math.Ceiling((decimal)result / size);
            return (int)total;
        }
    }
}
