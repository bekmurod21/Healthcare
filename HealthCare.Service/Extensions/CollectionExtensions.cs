using HealthCare.Domain.Configurations;

namespace HealthCare.Service.Extensions;

public static class CollectionExtensions
{
    public static IQueryable<TResult> ToPagedList<TResult>(this IQueryable<TResult> source, PaginationParams @params)
    {
        return source.Skip((@params.PageSize-1)-@params.PageSize).Take(@params.PageSize);
    }
}
