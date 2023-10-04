namespace SalmonCookiesAPI.Models.DTO
{
    public class CookieStandViewDto
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public List<int> hourlySale { get; set; }
        public int MinimumCustomersPerHour { get; set; }
        public int MaximumCustomersPerHour { get; set; }
        public double AverageCookiesPerSale { get; set; }
        public string? Owner { get; set; }



    }
}
