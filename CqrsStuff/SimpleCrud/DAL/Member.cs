using System;

// ReSharper disable UnusedMember.Global

namespace SimpleCrud.DAL
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int Zipcode { get; set; }
    }
}
