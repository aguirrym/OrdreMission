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
        public string Sexe { get; set; }
        public string ConnuComme { get; set; }
        public DateTime CreeLe { get; set; }
        public DateTime DernierActivation {get; set;}
        public string Recherche { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}