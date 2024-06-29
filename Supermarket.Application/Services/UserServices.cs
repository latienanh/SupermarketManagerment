using AutoMapper;
using Supermarket.Application.DTOs.Auth.RequestDtos;
using Supermarket.Application.DTOs.Auth.ResponseDtos;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.IRepositories;
using Supermarket.Application.IServices;
using Supermarket.Application.UnitOfWork;

namespace Supermarket.Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository<UserRequestDto,UserUpdateRequestDto,UserResponseDto> _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserServices(IUserRepository<UserRequestDto,UserUpdateRequestDto, UserResponseDto> userRepository,IMapper mapper,IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<UserResponseDto>> GetAllAsync()
        {
            var result = await _userRepository.GetAll();
            return result;
        }

        public async Task<UserResponseDto> GetByIdAsync(Guid id)
        {
            var result = await _userRepository.GetByIdAsync(id);
            return result;
        }

        public async Task<bool> CreateAsync(UserRequestDto entity)
        {
            var result = await _userRepository.AddAsync(entity);
            if (result == null)
                return false;
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(UserUpdateRequestDto entity, Guid id)
        {
            var result = await _userRepository.UpdateAsync(entity, id);
            if (result == null)
                return false;
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _userRepository.DeleteAsync(id);
            if (result == null)
                return false;
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
