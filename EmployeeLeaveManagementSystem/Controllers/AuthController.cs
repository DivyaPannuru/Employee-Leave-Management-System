using EmployeeLeaveManagementSystem.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeLeaveManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _context;
        public AuthController(IConfiguration config, ApplicationDbContext context)
        {
            _config = config;
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User userLogin)
        {
            var user = Authenticate(userLogin);
            if (user != null)
            {
                var token = GenerateToken(user);
                return Ok(new { token,user });
            }

            return Unauthorized();
        }

        private LoginUser Authenticate(User userLogin)
        {
            
            var User = (from a in _context.Users
                         where a.Username == userLogin.Username && a.Password == userLogin.Password
                        // && a.UserRole == userLogin.UserRole
                         select new User
                         {
                             Username = a.Username,
                            UserRole =a.UserRole
                         }).FirstOrDefault();
            var roles = _context.Users.Where(a => a.Username == userLogin.Username && a.Password.Equals(userLogin.Password))
                .Select(a => a.UserRole).ToList();
            
            // Replace with your user authentication logic
            if (User !=null)
            {
                //var claim = new List<Claim>()
                //{
                //   // new Claim(JwtRegisteredClaimNames.Sub,_config["Jwt:Subject"])
                //   new Claim("id", User.Id.ToString()),
                //   new Claim("Username", User.Username),
                //   new Claim("Role", User.UserRole)
                //};

                return new LoginUser { Username = userLogin.Username , Roles=roles};
            }

            return null;
        }

        private string GenerateToken(LoginUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, user.Username),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(ClaimTypes.Name, user.Username),
    };
           
            // Add roles as claims if the user has roles
            if (user.Roles != null && user.Roles.Any())
            {
                claims.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role, role)));
            }

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }

}
