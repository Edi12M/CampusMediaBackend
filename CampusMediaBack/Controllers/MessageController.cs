using CampusMediaBack.DTOs;
using CampusMediaBack.Models;
using CampusMediaBack.Services;
using ChatBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CampusMediaBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MessageController : ControllerBase
    {
        private readonly MessageService _service;
        private readonly ICurrentUserService _currentUser;

        public MessageController(MessageService service, ICurrentUserService currentUser)
        {
            _service = service;
            _currentUser = currentUser;
        }

        [HttpPost("send")]
        public async Task<ActionResult<Message>> SendMessage([FromBody] SendMessageDto dto)
        {
            var senderId = _currentUser.GetCurrentUserId();
            if (senderId == null) return Unauthorized();
            var message = await _service.SendMessageAsync(senderId.Value, dto);
            return Ok(message);
        }

        /// <summary>Get message history between current user and another user.</summary>
        [HttpGet("history")]
        public async Task<ActionResult<List<MessageResponseDto>>> GetHistory([FromQuery] int otherUserId)
        {
            var currentUserId = _currentUser.GetCurrentUserId();
            if (currentUserId == null) return Unauthorized();
            var messages = await _service.GetChatHistoryAsync(currentUserId.Value, otherUserId);
            return Ok(messages);
        }

        [HttpPost("mark-read")]
        public async Task<IActionResult> MarkRead([FromQuery] int senderId)
        {
            var receiverId = _currentUser.GetCurrentUserId();
            if (receiverId == null) return Unauthorized();
            await _service.MarkMessagesAsReadAsync(receiverId.Value, senderId);
            return Ok();
        }
    }
}
