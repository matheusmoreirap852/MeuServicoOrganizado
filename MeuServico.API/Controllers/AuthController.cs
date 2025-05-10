// MeuServico.API/Controllers/AuthController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MeuServico.API.Models;
using MeuServico.Infrastructure.Data;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole>     _roleManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IConfiguration                 _config;

    public AuthController(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole>     roleManager,
        SignInManager<ApplicationUser> signInManager,
        IConfiguration                 config)
    {
        _userManager   = userManager;
        _roleManager   = roleManager;
        _signInManager = signInManager;
        _config        = config;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        // 1) Cria o usuário
        var user = new ApplicationUser
        {
            UserName = dto.Email,
            Email    = dto.Email,
            DataCadastro = DateTime.UtcNow,
            Ativo    = true
        };

        var result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
            return BadRequest(result.Errors);

        // 2) Garante que as roles existam
        foreach (var roleName in new[] { "User", "Admin" })
            if (!await _roleManager.RoleExistsAsync(roleName))
                await _roleManager.CreateAsync(new IdentityRole(roleName));

        // 3) Atribui a role solicitada ou "User" por padrão
        var roleToAssign = 
            string.Equals(dto.Role, "Admin", StringComparison.OrdinalIgnoreCase)
            ? "Admin"
            : "User";

        await _userManager.AddToRoleAsync(user, roleToAssign);

        return Ok(new { message = $"Usuário '{dto.Email}' criado com role '{roleToAssign}'." });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var signInResult = await _signInManager.PasswordSignInAsync(
            dto.Email, dto.Password, isPersistent: false, lockoutOnFailure: false);

        if (!signInResult.Succeeded)
            return Unauthorized(new { message = "Credenciais inválidas" });

        var user = await _userManager.FindByEmailAsync(dto.Email);

        // Gera token com claims de role
        var token = await GenerateJwtToken(user!);
        return Ok(new { token });
    }

    private async Task<string> GenerateJwtToken(ApplicationUser user)
    {
        var jwt    = _config.GetSection("Jwt");
        var key     = jwt.GetValue<string>("Key")!;
        var keyBytes = Encoding.UTF8.GetBytes(key);
        var creds   = new SigningCredentials(
                          new SymmetricSecurityKey(keyBytes),
                          SecurityAlgorithms.HmacSha256);

        // Claims padrão
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            new Claim(JwtRegisteredClaimNames.Jti,  Guid.NewGuid().ToString())
        };

        // Adiciona roles
        var roles = await _userManager.GetRolesAsync(user);
        claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

        var expires = DateTime.UtcNow.AddMinutes(
                          jwt.GetValue<int>("ExpiresInMinutes"));

        var token = new JwtSecurityToken(
            issuer: jwt["Issuer"],
            audience: jwt["Audience"],
            claims: claims,
            expires: expires,
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
