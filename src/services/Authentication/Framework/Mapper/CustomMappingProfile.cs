using AutoMapper;

namespace Framework.Mapper;

public class CustomMappingProfile: Profile
{
    public CustomMappingProfile(IEnumerable<IMappable> enumerable)
    {
        foreach (var mappable in enumerable)
        {
            mappable.CreateMapping(this);
        }
    }
}