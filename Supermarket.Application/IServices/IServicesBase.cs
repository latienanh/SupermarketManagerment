namespace Supermarket.Application.IServices;

public interface IServicesBase<TRequestDto,TReponseDto>
{
    Task<IEnumerable<TReponseDto>> GetAllAsync();
    Task<TReponseDto> GetByIdAsync(Guid id);
    Task<bool> CreateAsync(TRequestDto entity,Guid userId);
    Task<bool> UpdateAsync(TRequestDto entity, Guid id, Guid userId);
    Task<bool> DeleteAsync(Guid id, Guid userId);
}