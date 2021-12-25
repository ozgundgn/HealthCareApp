using System.Collections.Generic;
using AutoMapper;

namespace Core.Extentions
{
    public static class MapperExtensions
    {
        public static void MapTo<T, Y>(this Y baseClass, T targetClass)
        {
            Mapper.CreateMap<Y, T>();
            Mapper.Map(baseClass, targetClass);
        }

        public static T MapTo<T, Y>(this Y baseClass) where T : new()
        {
            var target = new T();
            Mapper.CreateMap<Y, T>();
            Mapper.Map(baseClass, target);
            return target;
        }

        public static IEnumerable<D> MapListTo<S,D>(this IEnumerable<S> baseClass)
        {
            Mapper.CreateMap<S, D>();
            return Mapper.Map<IEnumerable<S>, IEnumerable<D>>(baseClass);

        }
    }
}
