using LibraryManagementSystemAPI.Dto;
using LibraryManagementSystemAPI.Services;
using LibraryManagementSystemAPI.Shared.Logging;
using LibraryManagementSystemAPI.Shared.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystemAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("CORSOpenPolicy")]
    public class UserController : ControllerBase
    {
        private readonly IUser _IUser;
        IAppLogger _Logger;
        public UserController(IUser user, IAppLogger logger)
        {
            this._IUser = user;
            this._Logger = logger;
        }
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                BaseResponse response = await this._IUser.GetUsers();
                return Ok(response);
            }
            catch (Exception ex)
            {
                _Logger.LogError(GetType().Name, ex);
                return BadRequest();
            }

        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(string Id)
        {

            try
            {
                BaseResponse response = await this._IUser.GetUserById(Id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _Logger.LogError(GetType().Name, ex);
                return BadRequest();
            }

        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(UserDto user)
        {
            try
            {
                if (user == null)
                    return BadRequest(ModelState);

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                BaseResponse response = await this._IUser.CreateUser(user);

                return Ok(response);
            }
            catch (Exception ex)
            {
                _Logger.LogError(GetType().Name, ex);
                return BadRequest();
            }

        }

        [Route("DeleteById")]
        [HttpDelete]
        //[Authorize("PlateformScope")]
        public async Task<IActionResult> DeleteById(string Id)
        {
            try
            {
                BaseResponse response = await this._IUser.DeleteById(Id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _Logger.LogError(GetType().Name, ex);
                return BadRequest();
            }
        }

        [Route("UpdateUser")]
        [HttpPut]
        //[Authorize("PlateformScope")]
        public async Task<IActionResult> UpdateUser(UserDto user)
        {
            try
            {
                BaseResponse response = await _IUser.UpdateUser(user);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _Logger.LogError(GetType().Name, ex);
                return BadRequest();
            }
        }

        [HttpGet("ChangeBlockStatus/{status}/{id}")]
        public async Task<IActionResult> ChangeBlockStatus(int status, string id)
        {
            if (status == 1)
            {
                BaseResponse response = await _IUser.BlockUser(id);
                return Ok(response);
            }
            else
            {
                BaseResponse response = await _IUser.UnblockUser(id);
                return Ok(response);
            }
        }

        [HttpGet("ChangeEnableStatus/{status}/{id}")]
        public async Task<IActionResult> ChangeEnableStatus(int status, string id) 
        { 

            if (status == 1)
            {
                BaseResponse response = await _IUser.ActivateUser(id);
                return Ok(response);

            }
            else
            {
                BaseResponse response = await _IUser.DeactivateUser(id);
                return Ok(response);

            }
        }
    }

}

