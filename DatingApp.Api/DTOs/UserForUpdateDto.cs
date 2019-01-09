namespace DatingApp.Api.DTOs
{
    public class UserForUpdateDto
    {
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interestes { get; set; }
        public int CityId { get; set; }
        public int GenderId { get; set; }
    }
}