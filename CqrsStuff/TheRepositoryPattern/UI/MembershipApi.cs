using System.Collections.Generic;
using TheRepositoryPattern.BLL;
using TheRepositoryPattern.DAL;
// ReSharper disable UnusedMember.Global

namespace TheRepositoryPattern.UI
{
    public class MembershipApi
    {
        private readonly MembershipLogic logic;

        public MembershipApi(MembershipLogic logic)
        {
            this.logic = logic;
        }

        public IEnumerable<Member> GetExpiredMembers()
        {
            return logic.GetExpiredMembers();
        }
    }
}