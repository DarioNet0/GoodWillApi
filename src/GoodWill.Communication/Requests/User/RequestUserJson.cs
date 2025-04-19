namespace GoodWill.Communication.Requests.User
{
    public class RequestUserJson
    {
        public long UserId { get; set; }
        public string Cpf { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
