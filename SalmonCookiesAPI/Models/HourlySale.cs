namespace SalmonCookiesAPI.Models
{
    public class HourlySale
    {
        public int Id { get; set; }

        public int StandCookieId { get; set; }

        public int salesvalue { get; set; }

        public CookieStand cookieStand { get; set; }
    }
}
