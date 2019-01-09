using System.Collections.Generic;

namespace DatingApp.Api.DTOs
{
    public class CountryDto : DtoAbstruct
    {
        public string CountryName { get; set; }

        public IEnumerable<CityDto> Cities { get; set; }
    }
}