using System;
using System.Collections.Generic;
using System.Linq;
using TheRepositoryPattern.DAL;

namespace TheRepositoryPattern.BLL
{
    public class GetMembersFromIds : IQuery<Member>
    {
        private readonly IEnumerable<Guid> ids;

        public GetMembersFromIds(IEnumerable<Guid> ids)
        {
            this.ids = ids;
        }

        public IEnumerable<Member> Query(IEnumerable<Member> members)
        {
            return members.Where(member => ids.Contains(member.Id))
                .ToList();
        }
    }
}