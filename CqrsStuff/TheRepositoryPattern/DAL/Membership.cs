using System;

// ReSharper disable UnusedMember.Global

namespace TheRepositoryPattern.DAL
{
    public class Membership
    {
        public Guid Id { get; set; }
        public Guid Member { get; set; }
        public Club Club { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}