using System;

namespace OrdreMission.API.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url  { get; set; }
        public bool IsMain { get; set; }
    }
}