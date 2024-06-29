namespace Supermarket.Application.IServices
{
    public interface IServicesBasic<TRequestDto,TUpdateRequestDto, TReponseDto>
    {
        Task<IEnumerable<TReponseDto>> GetAllAsync();
        Task<TReponseDto> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(TRequestDto entity);
        Task<bool> UpdateAsync(TUpdateRequestDto entity, Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}
