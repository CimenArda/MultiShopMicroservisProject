using Microsoft.EntityFrameworkCore;
using MultiShop.Message.Entities;

namespace MultiShop.Message.Context
{
    public class MessageContext:DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options):base(options)
        {

        }
        public DbSet<UserMessage>  UserMessages { get; set; }
    }
}
