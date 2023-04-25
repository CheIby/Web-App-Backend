using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using server.DTO.User;
using server.data;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using System;    
using System.IO;  

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly WebAppDbContext WebAppDbContext;
        private readonly IConfiguration Configuration;

        public UserController(WebAppDbContext WebAppDbContext, IConfiguration Configuration)
        {
            this.WebAppDbContext = WebAppDbContext;
            this.Configuration = Configuration;
        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<UserDTO>>> Get()
        {
            var List = await WebAppDbContext.Users.Select(
                s => new UserDTO
                {
                    UserId = s.UserId,
                    Username = s.Username,
                    Password = s.Password,
                    Score = s.Score,
                    FistName = s.FistName,
                    LastName = s.LastName,
                    Success = s.Success,
                    Failed = s.Failed
                    }
            ).ToListAsync();

            var sorted = List.OrderBy(e => e.Score).ToList();

            if (sorted.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return sorted;
            }
        }

        [HttpPatch("[action]/{UserId}")]
        [Authorize]
        public async Task<HttpStatusCode> UpdateUser(string UserId,[FromForm] UpdateUserDTO updateUser){
            var foundUser = await WebAppDbContext.Users.FindAsync(UserId);
            if (User is null){
                return HttpStatusCode.NotFound;
            }
            try{
                    if(foundUser.UserImg!="nullUser.png"){
                        var oldFilepath = Path.Combine(Directory.GetCurrentDirectory(),"static",foundUser.UserImg);
                        FileInfo oldFile = new FileInfo(oldFilepath);
                        oldFile.Delete();
                    }
                    var filepath = Path.Combine(Directory.GetCurrentDirectory(),"static",updateUser.Image.FileName);
                    foundUser.UserImg=  updateUser.Image.FileName.ToString();
                    foundUser.FistName = updateUser.FirstName;
                    foundUser.LastName = updateUser.LastName;
                    await updateUser.Image.CopyToAsync(new FileStream(filepath, FileMode.Create));
                    await WebAppDbContext.SaveChangesAsync();
                    return HttpStatusCode.OK;
                 }catch(Exception err){
                return HttpStatusCode.BadRequest;
                }
        }

        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> GetUserById()
        {   
            string authHeader = Request.Headers["Authorization"];
            string[] lstAuthHeader = authHeader.Split(" "); 
            var token = lstAuthHeader[1];
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken decodedToken = tokenHandler.ReadJwtToken(token);
            var claims = decodedToken.Claims;
            string UserId = claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
            UserDTO User = await WebAppDbContext.Users.Select(s => new UserDTO
            {
                UserId = s.UserId,
                Username = s.Username,
                Password = s.Password,
                FistName = s.FistName,
                LastName=s.LastName,
                Score = s.Score,
                UserImg = s.UserImg,
                Success = s.Success,
                Failed = s.Failed
            }).FirstOrDefaultAsync(s => s.UserId == UserId);
            if (User == null)
            {
                return NotFound();
            }
            else
            {
                var userInfo = new UserInfoDTO();
                userInfo.Username = User.Username;
                userInfo.Score = User.Score;
                userInfo.UserImg = User.UserImg;
                userInfo.FirstName = User.FistName;
                userInfo.LastName = User.LastName;
                userInfo.Success =User.Success;
                userInfo.Failed = User.Failed;
                return Ok(userInfo);
            }
        }
    }
}