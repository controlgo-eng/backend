using AutoMapper;

namespace Worldsys.Application.Mappers
{
    public interface ICreateMapper<TSource>
    {
        void Map(Profile profile)
        {
            profile.CreateMap(typeof(TSource), GetType()).ReverseMap();
        }
    }
}
