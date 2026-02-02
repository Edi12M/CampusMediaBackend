using CampusMediaBack.DTOs;
using CampusMediaBack.Services;
using ChatBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CampusMediaBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ConversationController : ControllerBase
    {
        private readonly ConversationService _service;
        private readonly ICurrentUserService _currentUser;

        public ConversationController(ConversationService service, ICurrentUserService currentUser)
        {
            _service = service;
            _currentUser = currentUser;
        }

        /// <summary>Get conversations for the logged-in user.</summary>
        [HttpGet]
        public async Task<ActionResult<List<ConversationDto>>> GetMyConversations()
        {
            var userId = _currentUser.GetCurrentUserId();
            if (userId == null) return Unauthorized();
            var conversations = await _service.GetUserConversationsAsync(userId.Value);
            return Ok(conversations);
        }
    }
}
