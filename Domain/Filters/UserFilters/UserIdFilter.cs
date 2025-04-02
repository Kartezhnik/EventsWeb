using Domain.Abstractions;
using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Filters.EventFilters
{
    public sealed class UserIdFilter : IFilter<User>
    {
        private readonly Guid _id;

        public UserIdFilter(Guid id)
        {
            _id = id;
        }

        public Expression<Func<User, bool>> Filter()
        {
            return e => e.Id == _id;
        }
    }
}   