using demo.webapi.demo.EFCore;
using demo.webapi.demo.Models;
using demo.webapi.demo.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demo.webapi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly DemoDbContext _dbContext;
        private readonly IAuthentication _authentication;
        public UserProfileController(DemoDbContext dbContext,IAuthentication authentication)
        {
            _dbContext = dbContext; 
            _authentication = authentication;   
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Login([FromBody] LoginDto loginDTO)
        {
            try
            {
                var response = new LoginResponse();
                //var userExists = await _context.UserProfiles.Where(x => ((x.EmailAddress.ToLower() == loginDTO.Email.ToLower()) || (x.UserName.ToLower() == loginDTO.Email.ToLower())) && (x.IsActive) && (!x.IsDelete));

                var userExists = await _dbContext.UserProfiles.Where(x => x.EmailId.ToLower() == loginDTO.Email.ToLower() ).FirstOrDefaultAsync();
                if (userExists != null)
                {
                    //var userdecryptpassword = Helper.DecryptString(Helper.SymmetricSecurityKey, userExists.Password);
                    if (userExists.Password != loginDTO.Password)
                    {
                        response.ErrorMessage += "Invalid Password.";
                    }
                    else
                    {
                        TokenModel tokenrespone = await _authentication.GenerateJwtToken(userExists.Name, userExists.PkUser);
                        //userExists.ModifiedDate = DateTime.Now;
                        response.ErrorMessage += null;
                        response.TokenModel = tokenrespone;
                    }
                }
                else
                {
                    response.ErrorMessage += "User Doesn't Exists.";
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
