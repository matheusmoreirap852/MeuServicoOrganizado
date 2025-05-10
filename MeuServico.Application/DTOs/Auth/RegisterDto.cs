namespace MeuServico.Application.DTOs.Auth
{
    public record RegisterDto(
        string Email,
        string Password,
        string? Role    // opcional: "User" ou "Admin"
    );
}
