using API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using API.Entities;
using Microsoft.AspNetCore.Authorization;
// added comment to commit

namespace API.Controllers
{
    public class UsersController : BaseAPIController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }    
        
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<AppUser>>> GetUsers()
        {
            return await _context.Users.ToListAsync();

        }
        
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}