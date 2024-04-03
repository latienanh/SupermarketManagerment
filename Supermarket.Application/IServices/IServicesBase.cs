namespace Supermarket.Application.IServices;

public interface IServicesBase<TRequestDto,TReponseDto>
{
    Task<IEnumerable<TReponseDto>> GetAllAsync();
    Task<TReponseDto> GetByIdAsync(int id);
    Task<bool> CreateAsync(TRequestDto entity);
    Task<bool> UpdateAsync(TRequestDto entity, int id);
    Task<bool> DeleteAsync(int id);
}