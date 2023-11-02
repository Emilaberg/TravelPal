namespace TravelPal.Interfaces
{
    public interface IUser
    {
        public int Id { get; }
        public string Username { get; set; }
        public string Password { get; set; }
        public object Location { get; set; }

        public string GetInfo();
    }
}
