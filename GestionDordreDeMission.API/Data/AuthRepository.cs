using System;
using System.Threading.Tasks;
using GestionDordreDeMission.API.Data;
using GestionDordreDeMission.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDordreDeMission.API.Controllers
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
          _context = context;

        }
        public async Task<User> connecter(string nom, string motdepasse)
        {
          var user = await _context.Users.FirstOrDefaultAsync(x => x.Nom == nom);
           
           if(user == null)
              return null;

           if(!VerifyPasswordHash(motdepasse, user.MotedepasseHash, user.Motedepassesalt))
           return null; 
           
           return user;
        }

        private bool VerifyPasswordHash(string motdepasse, byte[] motedepasseHash, byte[] motedepassesalt)
        {
           using(var hmac = new System.Security.Cryptography.HMACSHA512(motedepassesalt))
            {
               var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(motdepasse));
               for(int i =0; i < computedHash.Length; i++)
               {
                   if (computedHash[i] != motedepasseHash[i]) return false;
               }
            }
            return true;
        } 

        public async Task<User> Inscription(User user, string motdepasse)
        {
            byte[] motdepasseHash, motdepasseSalt;
            CreatePasswordHash(motdepasse, out motdepasseHash, out motdepasseSalt);

            user.MotedepasseHash = motdepasseHash;
            user.Motedepassesalt = motdepasseSalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string motdepasse, out byte[] motdepasseHash, out byte[] motdepasseSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                motdepasseSalt = hmac.Key;
                motdepasseHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(motdepasse));
            }
        }

        public async Task<bool> UtilisateurExiste(string nom)
        {
            if (await _context.Users.AnyAsync(x => x.Nom == nom))
             return true;

            return false;
        }
    }
}