using System;

// ReSharper disable UnusedMember.Global

namespace TheRepositoryPattern.DAL
{
    public class Member
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int Zipcode { get; set; }
    }
}
