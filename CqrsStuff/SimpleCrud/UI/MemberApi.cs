using System;
using SimpleCrud.BLL;
using SimpleCrud.DAL;
// ReSharper disable UnusedMember.Global

namespace SimpleCrud.UI
{
    public class MemberApi
    {
        private readonly MemberLogic logic;

        public MemberApi(MemberLogic logic)
        {
            this.logic = logic;
        }

        public Member Get(int id)
        {
            return logic.GetMember(id);
        }

        public int Post(string name, DateTime dob, int zipcode)
        {
            return logic.AddMember(name, dob, zipcode);
        }
    }
}