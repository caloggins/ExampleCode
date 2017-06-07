using System;
using System.Collections.Generic;

namespace TheRepositoryPattern.DAL
{
    public class MembershipRepository : IRepository<Membership>
    {
        public Membership GetById(Guid id)
        {
            return null;
        }

        public void Create(Membership member)
        {
        }

        public void Update(Membership member)
        {
        }

        public void Delete(Membership member)
        {
        }

        public IEnumerable<Membership> Query(IQuery<Membership> specification)
        {
            yield break;
        }
    }
}