using System;

namespace BeerBuddy
{
    public abstract class BaseEntity
    {
        public int id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}