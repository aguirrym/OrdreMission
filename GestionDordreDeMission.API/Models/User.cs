namespace GestionDordreDeMission.API.Models
{
    public class User
    {
        public int Id { get; set;}

        public string Nom{ get; set;}
        public byte[] MotedepasseHash { get; set; }
        public byte[] Motedepassesalt{ get; set;}

    }
}