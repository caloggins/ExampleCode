using System;
using SimpleCrud.DAL;

namespace SimpleCrud.BLL
{
    public class MemberValidator
    {
        public void Validate(Member member)
        {
            if (string.IsNullOrWhiteSpace(member.Name))
                throw new InvalidOperationException();
        }
    }
}