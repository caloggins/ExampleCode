using System.Collections.Generic;

// ReSharper disable UnusedMember.Global

namespace SimpleCrud.DAL
{
    public interface IQuery
    {
        IEnumerable<Member> Query(IEnumerable<Member> members);
    }
}