using SalmonCookiesAPI.Models.DTO;

namespace SalmonCookiesAPI.Models.Interfaces
{
    public interface ICookieStand
    {
        Task Create(CookieStandDto cookieStand);

        Task<IEnumerable<CookieStandViewDto>> GetAll();

        Task<CookieStandViewDto> GetById(int id);

        Task Delete(int id);

        Task<CookieStand> Update(int id, CookieStandDto updatedCookieStand);

    }
}
