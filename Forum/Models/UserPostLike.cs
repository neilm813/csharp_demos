using System;
using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public class UserPostLike // Many To Many 'Through' / 'Join' Table
    {
        [Key]
        public int UserPostLIkeId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /*
        Foreign Keys and Navigation Properties for Relationships

        Navigation properties will be null unless you use .Include / .ThenInclude
        */
        public int UserId { get; set; }
        public int PostId { get; set; }
        public User User { get; set; }
        public Post Post { get; set; }
    }
}