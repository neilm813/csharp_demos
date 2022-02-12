using System.Collections.Generic;

namespace FavoriteVideos.Models
{
    public class RegisterView
    {
        public List<int> LuckyNumbers { get; set; } = new List<int>();
        public User NewUser { get; set; }
    }
}