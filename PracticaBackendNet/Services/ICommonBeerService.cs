using PracticaBackendNet.DTOs;

namespace PracticaBackendNet.Services
{
    public interface ICommonBeerService<T, TI, TU>
    {
        public List<string> Errors { get; }
        Task<IEnumerable<BeerDto>> Get();
        Task<T> GetById(int id);
        Task<T> Add(TI beerInsertDto);
        Task<T> Update(int id, TU beerUpdateDto);
        Task<T> Delete(int id);
        bool Validate(TI dto);
        bool Validate(TU dto);
    }
}
