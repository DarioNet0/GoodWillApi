namespace GoodWill.Communication.Responses
{
    public class ResponseUserJson
    {
        public long UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
