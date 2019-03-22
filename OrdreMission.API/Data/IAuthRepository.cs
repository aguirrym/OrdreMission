using System.Threading.Tasks;
using OrdreMission.API.Models;

namespace OrdreMission.API.Data
{
    public interface IAuthRepository
    {
        Task<User> Inscription(User user, string motdepasse) ;
        Task<User> connecter(string nom, string motdepasse);
        Task<bool> UtilisateurExiste(string nom );
         
    }
}