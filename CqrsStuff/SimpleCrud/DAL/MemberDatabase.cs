using System.Collections.Generic;

namespace SimpleCrud.DAL
{
    public class MemberDatabase : List<Member>
    {
        public int Insert(Member member)
        {
            Add(member);
            return IndexOf(member);
        }
    }
}