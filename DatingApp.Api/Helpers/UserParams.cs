namespace DatingApp.Api.Helpers
{
    public class UserParams
    {
        private const int MAXPAGESIZE = 50;
        public int PageNumber { get; set; } = 1;
        public int pageSize = 10;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MAXPAGESIZE) ? MAXPAGESIZE : value; }
        }

        public int UserId { get; set; }
        public int? GenderId { get; set; }
        public int MinAge { get; set; } = 18;
        public int MaxAge { get; set; } = 50;
        public string OrderBy { get; set; }
    }
}