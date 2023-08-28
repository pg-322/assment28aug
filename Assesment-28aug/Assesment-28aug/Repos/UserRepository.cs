using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Assesment_28aug.Dbcontext;
using Assesment_28aug.Models;
using Microsoft.IdentityModel.Tokens;

namespace Assesment_28aug.Repos
{
    public class UserRepository
    {
        OrderDbContext _context;
        IConfiguration _config;
        public UserRepository(OrderDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        public User CheckUser(User user)
        {
            return _context.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
        }



        public string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);



            var claims = new ClaimsIdentity(new Claim[]



            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.GivenName, user.UserName)
            });



            var tokenHandler = new JwtSecurityTokenHandler();



            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"],
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = credentials



            };





            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);



        }



        public string Login(User user)
        {
            string response = null;
            User obj = CheckUser(user);
            if (obj == null)
            {
                return null;
            }
            response = GenerateToken(user);
            return response;



        }



        public User Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
