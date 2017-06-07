using System;
using System.Collections.Generic;
using System.Linq;
using TheRepositoryPattern.DAL;

namespace TheRepositoryPattern.BLL
{
    public class GetExpiredMemberships : IQuery<Membership>
    {
        public IEnumerable<Membership> Query(IEnumerable<Membership> memberships)
        {
            return memberships.Where(membership => membership.End < DateTime.Today)
                .ToList();
        }
    }
}