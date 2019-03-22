using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OrdreMission.API.Data;
using OrdreMission.API.Dtos;
using OrdreMission.API.Models;

namespace OrdreMission.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;
        }

        [HttpPost("inscription")]
         public async Task<IActionResult> Inscription(UserForRegisterDto  userForRegisterDto)
        {
           userForRegisterDto.Nom = userForRegisterDto.Nom.ToLower();

            if (await _repo.UtilisateurExiste(userForRegisterDto.Nom))
                return BadRequest("Utilisateur Existe Déja");

            var userToCreate = new User
            {
                Nom = userForRegisterDto.Nom
            };

            var createUser = await _repo.Inscription(userToCreate,  userForRegisterDto.Motdepasse);

            return StatusCode(201);
        }

        [HttpPost("connecter")]
        public async Task<IActionResult> connecter(UserForLoginDto userForLoginDto)
        {
        

             var userFromRepo = await _repo
                .connecter(userForLoginDto.Nom.ToLower(), userForLoginDto.Motdepasse);

            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[] 
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Nom)
            };
      
             //creating securty key

            var Key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(Key, SecurityAlgorithms
                    .HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            

            return Ok(new {
                token = tokenHandler.WriteToken(token)
            });  
        }   
    }   


    }
