using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockChat.Entities;

namespace StockChat.Repository
{
    public class StockChatDbContext: IdentityDbContext<UserEntity>
    {
        public StockChatDbContext(DbContextOptions<StockChatDbContext> options)
            : base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
        
        public DbSet<ChatMessage> Messages { get; set; }

     
        
    }
}
