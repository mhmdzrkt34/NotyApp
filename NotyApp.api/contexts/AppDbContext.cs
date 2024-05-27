using Microsoft.EntityFrameworkCore;
using NotyApp.api.models;

namespace NotyApp.api.contexts
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions options) : base(options)
        {


        }

        public DbSet<User> users { get; set; }

        public DbSet<Message> messages { get; set; }


        public DbSet<Contact> contacts { get; set; }

       public DbSet<UserRole> userRoles { get; set; }

        public DbSet<Role> roles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Contact>().HasOne(i => i.Sender).WithMany(j => j.addedContacts).HasForeignKey(k => k.sender_id).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Contact>().HasOne(i => i.reciever).WithMany(j => j.recievedContacts).HasForeignKey(k => k.reciever_id).OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Message>().HasOne(i => i.sender).WithMany(j => j.sendedMessages).HasForeignKey(k => k.sender_id).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Message>().HasOne(i => i.reciever).WithMany(j => j.recievedMessages).HasForeignKey(k => k.reciever_id).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserRole>().HasOne(i => i.user).WithMany(j => j.roles).HasForeignKey(k => k.user_id).OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<UserRole>().HasOne(i=>i.role).WithMany(j=>j.users).HasForeignKey(k=>k.role_id).OnDelete(DeleteBehavior.Cascade);





        }

    }
}
