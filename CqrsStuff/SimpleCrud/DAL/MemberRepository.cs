using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCrud.DAL
{
    public class MemberRepository : IMemberRepository
    {
        private readonly MemberDatabase database;

        public MemberRepository(MemberDatabase database)
        {
            this.database = database;
        }

        public Member GetById(int id)
        {
            return database.First(_ => _.Id == id);
        }

        public int Create(Member member)
        {
            return database.Insert(member);
        }

        public void Update(Member member)
        {
            var dead = database.First(_ => _.Id == member.Id);
            database.Remove(dead);
            database.Add(member);
        }

        public void Delete(Member member)
        {
            var dead = database.First(_ => _.Id == member.Id);
            database.Remove(dead);
        }

        public IEnumerable<Member> GetAdults()
        {
            return database.Where(user => DateTime.Today.Year - user.Birthday.Year > 20)
                .ToList();
        }

        public IEnumerable<Member> GetAdultsInZipcode(int zipcode)
        {
            return database.Where(user => DateTime.Today.Year - user.Birthday.Year > 20
                                          && user.Zipcode == zipcode)
                .ToList();
        }

        public IEnumerable<Member> QueryUsers(IQuery query)
        {
            return query.Query(database);
        }
    }
}