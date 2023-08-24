using DataAccessLayer.Contracts.Base;
using Entities.Models;
using MongoDB.Bson;

namespace DataAccessLayer.Contracts;

public interface ITokenRepository: IRepository<Token>
{
    Task<Token> CreateToken(ObjectId userId, Device device);

    Task<List<Token>> GetByUserId(ObjectId userId);

    Task<bool> RevokeToken(ObjectId id);
}