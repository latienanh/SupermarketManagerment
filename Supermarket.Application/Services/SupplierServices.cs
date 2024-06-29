using AutoMapper;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.IRepositories;
using Supermarket.Application.IServices;
using Supermarket.Application.UnitOfWork;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Application.Services
{
    public class SupplierServices:ISupplierServices
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISupplierRepository _supplierRepository;

        public SupplierServices (IMapper mapper, IUnitOfWork unitOfWork,ISupplierRepository supplierRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _supplierRepository = supplierRepository;
        }
        public async Task<IEnumerable<SupplierResponseDto>> GetAllAsync()
        {
            var result = await _supplierRepository.GetAllAsync();
            var resultMap = _mapper.Map<IEnumerable<SupplierResponseDto>>(result);
            return resultMap;
        }

        public async Task<SupplierResponseDto> GetByIdAsync(Guid id)
        {
            var result = await _supplierRepository.GetSingleByIdAsync(id);
            var resultMap = _mapper.Map<SupplierResponseDto>(result);
            return resultMap;
        }

        public async Task<bool> CreateAsync(SupplierRequestDto entity, Guid userId)
        {
            if (entity == null)
                return false;
            var supplier = _mapper.Map<Supplier>(entity);
            var result = await _supplierRepository.AddAsync(supplier, userId);
            if (result == null)
                return false;
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(SupplierRequestDto entity, Guid id, Guid userId)
        {
            if (entity == null)
                return false;
            var supplierUpdate = _mapper.Map<Supplier>(entity);
          
            var entityType = "Supplier";
            var result = await _supplierRepository.UpdateAsync(supplierUpdate, id, entityType, userId);
            if (result == null)
                return false;
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id, Guid userId)
        {
            var result = await _supplierRepository.DeleteAsync(id, userId);
            if (result == null)
                return false;
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<IEnumerable<SupplierResponseDto>> getPagingAsync(int index, int size)
        {
            var result = await _supplierRepository.GetMultiPagingAsync(x => x.IsDelete == false, index, size);
            var resultMap = _mapper.Map<IEnumerable<SupplierResponseDto>>(result);
            return resultMap;
        }

        public async Task<int> getTotalPagingTask(int size)
        {
            var result = await _supplierRepository.CountAsync(x => x.IsDelete == false);
            decimal total = Math.Ceiling((decimal)result / size);
            return (int)total;
        }
    }
}
