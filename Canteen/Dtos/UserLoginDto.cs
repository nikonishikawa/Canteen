namespace Canteen.Dtos
{
    public class UserLoginDto
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string UserToken { get; set; }
        public string NewRefreshToken { get; set; }
        public List<string> UserRole { get; set; }
    }
}
