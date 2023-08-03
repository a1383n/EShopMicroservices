using AutoMapper;

namespace Framework.Mapper;

public interface IMappable
{
    void CreateMapping(Profile profile);
}