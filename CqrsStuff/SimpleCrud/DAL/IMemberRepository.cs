using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global

namespace SimpleCrud.DAL
{
    public interface IMemberRepository
    {
        Member GetById(int id);
        int Create(Member member);
        void Update(Member member);
        void Delete(Member member);
        IEnumerable<Member> GetAdults();
        IEnumerable<Member> GetAdultsInZipcode(int zipcode);
        IEnumerable<Member> QueryUsers(IQuery specification);
    }
}