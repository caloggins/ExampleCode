using System;
using System.Linq;
using SimpleCrud.DAL;

namespace SimpleCrud.BLL
{
    public class MemberLogic
    {
        private readonly MemberValidator validator;
        private readonly MemberRepository repository;

        public MemberLogic(MemberValidator validator, MemberRepository repository)
        {
            this.validator = validator;
            this.repository = repository;
        }

        public Member GetMember(int id)
        {
            var getMemberById = new GetMemberById(id);
            return repository.QueryUsers(getMemberById).First();
        }

        public int AddMember(string name, DateTime dob, int zipcode)
        {
            var member = new Member
            {
                Birthday = dob,
                Name = name,
                Zipcode = zipcode
            };
            validator.Validate(member);
            return repository.Create(member);
        }
    }
}