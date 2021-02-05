using ApiUser.Data;
using ApiUser.Data.Entites;
using ApiUser.Resources.User;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUser.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;
        public UserController(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult Get()
        {
            var users = _context.Users.ToList();
            var userResource = _mapper.Map<IEnumerable<UserResource>>(users);
            return Ok(userResource);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int? id)
        {
            if (id == null) return NotFound();
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound(new { message = "User NotFound" });
            var userResource = _mapper.Map<UserResource>(user);
            return Ok(userResource);
        }


        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] RegisterResource register)
        {
            if (_context.Users.Any(x => x.Email == register.Email)) return Conflict(new
            {
                message = "This Email alredy exists"
            });

            var user = _mapper.Map<RegisterResource, User>(register);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }


        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] LoginResource login)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == login.Email);
            if (user != null)
            {
                if (CryptoHelper.Crypto.VerifyHashedPassword(user.Password, login.Password))
                {
                    user.Token = CryptoHelper.Crypto.HashPassword(DateTime.Now.ToString());
                    await _context.SaveChangesAsync();
                    var userResource = _mapper.Map<User, UserResource>(user);
                    return Ok(userResource);
                }
            }

            return NotFound(new
            {
                message = "Email Or Password Incorrect"
            });
        }

       
        


    }
}
