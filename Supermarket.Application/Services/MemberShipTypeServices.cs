using AutoMapper;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.IRepositories;
using Supermarket.Application.IServices;
using Supermarket.Application.UnitOfWork;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Application.Services
{
    public class MemberShipTypeServices:IMemberShipTypeServices
    {
    
        private readonly IMapper _mapper;
        private readonly IMemberShipTypeRepository _memberShipTypeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public MemberShipTypeServices(IMemberShipTypeRepository memberShipTypeRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _memberShipTypeRepository = memberShipTypeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<MemberShipTypeResposeDto>> GetAllAsync()
        {
            var result = await _memberShipTypeRepository.GetAllAsync();
            var resultMap = _mapper.Map<ICollection<MemberShipTypeResposeDto>>(result);
            return resultMap;
        }

        public async Task<MemberShipTypeResposeDto> GetByIdAsync(Guid id)
        {
            var result = await _memberShipTypeRepository.GetSingleByIdAsync(id);
            var resultMap = _mapper.Map<MemberShipTypeResposeDto>(result);
            return resultMap;
        }

        public async Task<bool> CreateAsync(MemberShipTypeRequestDto entity, Guid userId)
        {
            if (entity == null)
                return false;
            var entityMap = _mapper.Map<MemberShipType>(entity);
            var result = await _memberShipTypeRepository.AddAsync(entityMap, userId);
            if (result == null)
                return false;
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(MemberShipTypeRequestDto entity, Guid id, Guid userId)
        {
            if (entity == null)
                return false;
            var MemberShipTypeValue = _mapper.Map<MemberShipType>(entity);
            var entityType = "MemberShipType";
            var result = await _memberShipTypeRepository.UpdateAsync(MemberShipTypeValue, id, entityType, userId);
            if (result == null)
                return false;
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id, Guid userId)
        {
            var result = await _memberShipTypeRepository.DeleteAsync(id, userId);
            if (result == null)
                return false;
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
