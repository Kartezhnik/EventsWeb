using Domain.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Filters.ParticipationFilter
{
    public sealed class ParticipationIdFilter : IFilter<Participation>
    {
        private readonly Guid _id;

        public ParticipationIdFilter(Guid id)
        {
            _id = id;
        }

        public Expression<Func<Participation, bool>> Filter()
        {
            return e => e.Id == _id;
        }
    }
}
