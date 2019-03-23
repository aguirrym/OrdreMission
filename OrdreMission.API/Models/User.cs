using System;
using System.Collections.Generic;

namespace OrdreMission.API.Models
{
    public class User
    {
         public int Id { get; set;}

        public string Nom{ get; set;}
        public byte[] MotedepasseHash { get; set; }
        public byte[] Motedepassesalt{ get; set;}
        public string Gender { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive {get; set;}
        public string LookingFor { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}