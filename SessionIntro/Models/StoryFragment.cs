using System.ComponentModel.DataAnnotations;

namespace SessionIntro.Models
{
    public class StoryFragment
    {
        [Required(ErrorMessage = "is required")]
        public string Word { get; set; }
    }
}