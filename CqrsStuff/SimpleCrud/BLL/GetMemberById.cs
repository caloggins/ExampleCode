using System.Collections.Generic;
using System.Linq;
using SimpleCrud.DAL;
// ReSharper disable UnusedMember.Global

namespace SimpleCrud.BLL
{
    public class GetMemberById : IQuery
    {
        private readonly int id;

        public GetMemberById(int id)
        {
            this.id = id;
        }

        public IEnumerable<Member> Query(IEnumerable<Member> members)
        {
            return members.Where(member => member.Id == id);
        }
    }
}