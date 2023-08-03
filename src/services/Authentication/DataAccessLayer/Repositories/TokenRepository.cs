using Common;
using DataAccessLayer.Contracts;
using DataAccessLayer.Repositories.Base;
using Entities.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataAccessLayer.Repositories;

public class TokenRepository : Repository<Token>, ITokenRepository, ISingletonDependency
{
    public TokenRepository(IMongoDbContext context) : base(context.GetCollection<Token>("tokens"))
    {
        //
    }

    public override FilterDefinition<Token> GetByIdFilter(ObjectId id)
    {
        return GetFilterDefinitionBuilder().Eq(token => token.Id, id);
    }

    public async Task<Token> CreateToken(ObjectId userId, Device device)
    {
        var token = new Token()
        {
            UserId = userId,
            Device = device,
            ExpireAt = null
        };

        await CreateAsync(token);
        return token;
    }

    public Task<List<Token>> GetByUserId(ObjectId userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RevokeToken(ObjectId id)
    {
        throw new NotImplementedException();
    }
}