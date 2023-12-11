

using AutoMapper;

namespace SuperLandscapes_Blog.Application.Common.Mappings.Interface
{
    public interface IMappingFrom<TEntity>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(TEntity), GetType());
    }
}
