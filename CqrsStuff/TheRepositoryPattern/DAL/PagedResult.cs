using System.Collections.Generic;

// ReSharper disable UnusedMember.Global

namespace TheRepositoryPattern.DAL
{
    public class PagedResult
    {
        public IEnumerable<Member> Users { get; set; }
        public int TotalUsers { get; set; }
    }
}