using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.IRepositories;
using Supermarket.Application.IServices;
using Supermarket.Application.UnitOfWork;

namespace Supermarket.Application.Services
{
    public class RoleServices : IRoleServices
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RoleServices(IRoleRepository roleRepository,IUnitOfWork unitOfWork,IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<RoleResponseDto>> GetAllAsync()
        {
            var result = await _roleRepository.GetAll();
            var resultMap = _mapper.Map<IEnumerable<RoleResponseDto>>(result
            );
            return resultMap;
        }

        public async Task<RoleResponseDto> GetByIdAsync(Guid id)
        {
            var result = await _roleRepository.GetByIdAsync(id);
            var resultMap = _mapper.Map<RoleResponseDto>(result
            );
            return resultMap;
        }

        public async Task<bool> CreateAsync(RoleRequestDto entity)
        {
            var entityMap = _mapper.Map<IdentityRole<Guid>>(entity);
            var result = await _roleRepository.AddAsync(entityMap);
            if (result == null)
                return false;
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(RoleRequestDto entity, Guid id)
        {
            var entityMap = _mapper.Map<IdentityRole<Guid>>(entity);
            var result = await _roleRepository.UpdateAsync(entityMap, id);
            if(result==null)
                return false;
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _roleRepository.DeleteAsync(id);
            if (result == null)
                return false;
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
