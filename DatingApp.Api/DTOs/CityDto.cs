namespace DatingApp.Api.DTOs
{
    public class CityDto : DtoAbstruct
    {
        public string CityName { get; set; }
        public CountryDto Country { get; set; }
    }
}