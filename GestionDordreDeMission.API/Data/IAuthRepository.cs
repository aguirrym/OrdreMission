using System.Threading.Tasks;
using GestionDordreDeMission.API.Models;

namespace GestionDordreDeMission.API.Data
{
    public interface IAuthRepository
    {
       Task<User> Inscription(User user, string motdepasse) ;
        Task<User> connecter(string nom, string motdepasse);
        Task<bool> UtilisateurExiste(string nom );
    } 
   
}