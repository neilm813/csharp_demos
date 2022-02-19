using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public class Post
    {
        [Key] // Primary Key
        public int PostId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Must be more than 2 characters.")]
        [MaxLength(45, ErrorMessage = "Must be less than 45 characters.")]
        public string Topic { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Must be more than 2 characters.")]
        public string Body { get; set; }

        [Display(Name = "Image Url")]
        public string ImgUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /* Relationships */

        //  Foreign Keys
        public int UserId { get; set; }

        // Navigation Properties (related class instances) - MUST use .Include to access.
        public User Author { get; set; } // 1 User : N Posts
        public List<UserPostLike> Likes { get; set; } // Many to Many likes.
    }
}