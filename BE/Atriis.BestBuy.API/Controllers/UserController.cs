using BestBuy.Abstractions.Endpoints;
using BestBuy.Abstractions.Routes;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace BestBuy.API.Controllers
{
    /// <summary>
    /// User Controller
    /// </summary>
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [Route(Routes.UserEndpoint)]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserEndpoint _userEndpoint;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userEndpoint"></param>
        public UserController(IUserEndpoint userEndpoint)
        {
            _userEndpoint = userEndpoint;
        }

        /// <summary>
        /// Get User By Credentials
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Abstractions.Models.User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserByCredentials([FromQuery] string username, [FromQuery] string password)
        {
            try
            {
                var operation = await _userEndpoint.GetUserByCredentialsAsync(username, password);
                return operation != null ? Ok(operation) : NotFound();
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Create a User
        /// </summary>
        /// <param name="user">New User</param>
        /// <returns>Return created User</returns>
        /// <response code="201">Return Created User</response>
        /// <response code="400">Invalid User.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Abstractions.Models.User), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser([FromBody] Abstractions.Models.User user)
        {
            try
            {
                var operation = await _userEndpoint.CreateUserAsync(user);
                return CreatedAtAction(nameof(GetUserByCredentials), new { username = operation.Username, password = operation.Password }, operation);
            }
            catch (ValidationException e)
            {
                foreach (FluentValidation.Results.ValidationFailure item in e.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            catch (ArgumentNullException e)
            {
                ModelState.AddModelError("", e.Message);
                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="user">User to Update</param>
        /// <response code="204">Success</response>
        /// <response code="400">Invalid User</response>
        /// <response code="404">User Not Found</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUser([FromBody] Abstractions.Models.User user)
        {
            try
            {
                await _userEndpoint.UpdateUserAsync(user);
                return Ok(user);
            }
            catch (ValidationException e)
            {
                foreach (FluentValidation.Results.ValidationFailure item in e.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            catch (ArgumentNullException e)
            {
                ModelState.AddModelError("", e.Message);
                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="id">User Id</param>
        /// <param name="deletedBy"></param>
        /// <returns></returns>
        /// <response code="204">User Deleted With Success.</response>
        /// <response code="400">Error.</response>
        /// <response code="404">User Not Found.</response>
        [HttpDelete(Routes.Delete)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteUser(long id, string deletedBy)
        {
            try
            {
                await _userEndpoint.DeleteUserAsync(id, deletedBy);
                return Ok(id);
            }
            catch (ArgumentNullException e)
            {
                ModelState.AddModelError("", e.Message);
                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
