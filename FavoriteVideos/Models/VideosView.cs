using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavoriteVideos.Models
{
    public class VideosViewModel
    {
        public List<string> YoutubeVideoIds { get; set; }
        public string Message { get; set; }
    }
}