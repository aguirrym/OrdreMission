using System.ComponentModel.DataAnnotations;

namespace OrdreMission.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public  string Nom { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Mot de passe entre 4 et 8 caractéres")]
         public string Motdepasse { get; set; }
    }
}