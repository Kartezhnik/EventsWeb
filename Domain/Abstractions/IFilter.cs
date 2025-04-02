using System.Linq.Expressions;

namespace Domain.Abstractions
{
    public interface IFilter<T>
    {
        Expression<Func<T, bool>> Filter();
    }
}
