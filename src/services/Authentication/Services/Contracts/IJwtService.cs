using Entities.Models;

namespace Services.Contracts;

public interface IJwtService
{
    Task<string> GenerateAsync(User user, Token token);
}