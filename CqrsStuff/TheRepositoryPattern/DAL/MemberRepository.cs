using System;
using System.Collections.Generic;
using System.Linq;

namespace TheRepositoryPattern.DAL
{
    public class MemberRepository : IRepository<Member>
    {
        private readonly Database database;

        public MemberRepository(Database database)
        {
            this.database = database;
        }

        public Member GetById(Guid id)
        {
            return database.Members.First(_ => _.Id == id);
        }

        public void Create(Member member)
        {
            member.Id = Guid.NewGuid();
            database.Members.Add(member);
        }

        public void Update(Member member)
        {
            var dead = database.Members.First(_ => _.Id == member.Id);
            database.Members.Remove(dead);
            database.Members.Add(member);
        }

        public void Delete(Member member)
        {
            var dead = database.Members.First(_ => _.Id == member.Id);
            database.Members.Remove(dead);
        }

        public IEnumerable<Member> GetAdults()
        {
            return database.Members.Where(user => DateTime.Today.Year - user.Birthday.Year > 20)
                .ToList();
        }

        public IEnumerable<Member> GetAdultsInZipcode(int zipcode)
        {
            return database.Members.Where(user => DateTime.Today.Year - user.Birthday.Year > 20
                                          && user.Zipcode == zipcode)
                .ToList();
        }

        public IEnumerable<Member> Query(IQuery<Member> query)
        {
            return query.Query(database.Members);
        }
    }
}