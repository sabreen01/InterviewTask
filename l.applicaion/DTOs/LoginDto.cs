namespace l.applicaion.DTOs
{
    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponseDto 
    {
    public string Message {  get; set; }
    public string? Token {  get; set; }
    public DateTime? ExpireAt { get; set; }
    }
}
