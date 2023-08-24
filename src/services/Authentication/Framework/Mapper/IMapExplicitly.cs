using AutoMapper;

namespace Framework.Mapper;

public interface IMapExplicitly
{
    void RegisterMappings(IProfileExpression profile);
}