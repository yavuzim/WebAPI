using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Context;
using WebAPI.Dtos.MessageDtos;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly APIContext context;

        public MessagesController(IMapper mapper, APIContext context)
        {
            this.mapper = mapper;   
            this.context = context;
        }
        [HttpGet]
        public IActionResult MessageList()
        {
            var values = context.Messages.ToList();
            return Ok(mapper.Map<List<ResultMessageDto>>(values));
        }

        [HttpGet("GetMessage")]
        public IActionResult MessageGet(int id)
        {
            var values = context.Messages.Find(id);
            return Ok(mapper.Map<GetByIdMessageDto>(values));
        }

        [HttpPost]
        public IActionResult MessageFeature(CreateMessageDto createMessageDto)
        {
            var value = mapper.Map<Message>(createMessageDto);
            context.Messages.Add(value);
            context.SaveChanges();
            return Ok("Message added successfully.");
        }

        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var value = context.Messages.Find(id);
            context.Messages.Remove(value);
            context.SaveChanges();
            return Ok("Message deleted successfully.");
        }

        [HttpPut]
        public IActionResult UpdatMessage(UpdateMessageDto updteMessageDto)
        {
            var value = mapper.Map<Message>(updteMessageDto);
            context.Messages.Update(value);
            return Ok("Message updated successfully.");
        }
    }
}