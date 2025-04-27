namespace UserService.Core.DTO
{
    public class AuthenticationResponse
    {
        public Guid UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public string? Token { get; set; }
        public bool IsSuccess { get; set; }
    }
}
