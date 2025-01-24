using AutoMapper;

namespace WebAPI
{
    public static class AutoMapperExtensions
    {
        public static IMappingExpression<TSource, TDestination> IgnoreAllNull<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> expression)
        {
            expression.ForAllMembers(options =>
            {
                options.Condition((src, dest, srcMember) => srcMember != null);
            });
            return expression;
        }
    }
}
