using System.Collections.Generic;
using System.Linq;
using TheRepositoryPattern.DAL;

namespace TheRepositoryPattern.BLL
{
    public class MembershipLogic
    {
        private readonly IRepository<Member> memberRepository;
        private readonly IRepository<Membership> membershipRepository;

        public MembershipLogic(IRepository<Member> memberRepository, IRepository<Membership> membershipRepository)
        {
            this.memberRepository = memberRepository;
            this.membershipRepository = membershipRepository;
        }

        public IEnumerable<Member> GetExpiredMembers()
        {
            var getExpiredMemberships = new GetExpiredMemberships();
            var memberships = membershipRepository.Query(getExpiredMemberships);

            var getMembersFromIds = new GetMembersFromIds(memberships.Select(membership => membership.Member));
            return memberRepository.Query(getMembersFromIds);
        }
    }
}