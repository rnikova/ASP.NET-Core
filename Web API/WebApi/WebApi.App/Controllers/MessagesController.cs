using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.App.Models;
using WebApi.Data;
using WebApi.Domain;

namespace WebApi.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly WebApiDbContext context;

        public MessagesController(WebApiDbContext context)
        {
            this.context = context;
        }

        [HttpGet(Name = "All")]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<Message>>> AllOrderedByCreatedOnAscending()
        {
            return this.context.Messages
                .OrderBy(message => message.CreatedOn)
                .ToList();
        }

        [HttpPost(Name = "Create")]
        [Route("create")]
        public async Task<ActionResult> Create(MessageCreateBindingModel model)
        {
            Message message = new Message
            {
                Content = model.Content,
                User = model.User,
                CreatedOn = DateTime.UtcNow
            };

            await this.context.Messages.AddAsync(message);
            await this.context.SaveChangesAsync();

            return this.Ok();
        }
    }
}
