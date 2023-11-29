using AutoMapper;
using System;

namespace ProduceDeliveryApp.Application.Abstract
{
    public static class AutoMapperExtensions
    {
        public static void IgnoreUnmapped(this IProfileExpression profile)
        {
            profile.ForAllMaps(IgnoreUnmappedProperties);
        }

        public static void IgnoreUnmapped(this IProfileExpression profile, Func<TypeMap, bool> filter)
        {
            profile.ForAllMaps((map, expr) =>
            {
                if (filter(map))
                {
                    IgnoreUnmappedProperties(map, expr);
                }
            });
        }

        public static void IgnoreUnmapped(this IProfileExpression profile, Type src, Type dest)
        {
            profile.IgnoreUnmapped(map => map.SourceType == src && map.DestinationType == dest);
        }

        public static void IgnoreUnmapped<TSrc, TDest>(this IProfileExpression profile)
        {
            profile.IgnoreUnmapped(typeof(TSrc), typeof(TDest));
        }

        private static void IgnoreUnmappedProperties(TypeMap map, IMappingExpression expr)
        {
            foreach (var propName in map.GetUnmappedPropertyNames())
            {
                if (map.SourceType.GetProperty(propName) != null)
                {
                    expr.ForSourceMember(propName, opt => opt.DoNotValidate());
                }

                if (map.DestinationType.GetProperty(propName) != null)
                {
                    expr.ForMember(propName, opt => opt.Ignore());
                }
            }

            //ignore different types
            foreach (var propName in map.PropertyMaps)
            {
                if (map.SourceType.GetProperty(propName.DestinationName) != null
                    && map.DestinationType.GetProperty(propName.DestinationName) != null
                    && map.SourceType.GetProperty(propName.DestinationName).PropertyType != map.DestinationType.GetProperty(propName.DestinationName).PropertyType)
                {
                    expr.ForMember(propName.DestinationName, opt => opt.Ignore());
                }
            }
        }
    }

}
