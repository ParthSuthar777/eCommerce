using Common.Helper.Enum;

namespace UserService.Core.DTO
{
    public record RegisterRequest
        (
            string Name,
            string? Email,
            string? Password,
            GenderOption Gender
        );
}
