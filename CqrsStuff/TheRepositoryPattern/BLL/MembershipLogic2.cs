using System;
using System.Collections.Generic;
using System.Linq;
using TheRepositoryPattern.DAL;
// ReSharper disable UnusedMember.Global

namespace TheRepositoryPattern.BLL
{
    public class MembershipLogic2
    {
        private readonly Database database;

        public MembershipLogic2(Database database)
        {
            this.database = database;
        }

        public IEnumerable<Member> GetExpiredMembers()
        {
            var expired = from membership in database.Memberships
                where membership.End < DateTime.Today
                select membership.Member;

            var members = from member in database.Members
                where expired.Contains(member.Id)
                select member;

            return members.ToList();
        }
    }
}