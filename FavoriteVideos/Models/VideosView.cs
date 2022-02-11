using System.Collections.Generic;

namespace FavoriteVideos.Models
{
    public class VideosView
    {
        public List<string> YoutubeVideoIds { get; set; } = new List<string>();
        public int RandomNumber { get; set; }

        public VideosView()
        {
            YoutubeVideoIds = new List<string>()
            {
            "5qap5aO4i9A", "EHtsQ9thkIY", "0rBG9BAiiC4", "cCwiZdFz63w", "fb9-OzVuV6g", "-y8aKyi6-OQ", "kVaiWk7H7n0",
            "UDA6Kd6uYqs", "eg9_ymCEAF8", "Q8vnqwtOf8E"
            };

            RandomNumber = new System.Random().Next();
        }
    }
}