using System.Collections.Generic;

namespace TheRepositoryPattern.DAL
{
    public class Database
    {
        public List<Member> Members = new List<Member>();

        public List<Membership> Memberships = new List<Membership>();
    }
}