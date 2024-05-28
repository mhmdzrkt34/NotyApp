
using NotyApp.api.contexts;
using NotyApp.api.models;

namespace NotyApp.api.Repositories.seedingRepository
{
    public class SeedingRepository : ISeedingRepository
    {

        private readonly AppDbContext _appDbContext;

        public SeedingRepository(AppDbContext appDbContext)
        {


            _appDbContext = appDbContext;   
        }
        public async Task SeedData()
        {
            try
            {

                List<User> users = new List<User>();

                List<Message> messages = new List<Message>();

                List<Role> roles=new List<Role>();

                List<Contact> contacts = new List<Contact>();
                List<UserRole> userRoles = new List<UserRole>();


                Role userRole = new Role
                {
                    name = "user"

                };


                roles.Add(userRole);
              


                for (int i = 0; i < 50; i++)
                {

                    User user = new User
                    {

                        email = $"user{i}@example.com",
                        password = BCrypt.Net.BCrypt.HashPassword("@Newpassword1")

                    };

                    users.Add(user);

                    userRoles.Add(new UserRole
                    {
                        role_id = userRole.id,
                        user_id = user.id


                    });


                }
                Random random = new Random();

                for(int i = 0; i < 50; i++)
                {

                    for(int j = 0; j < 15; j++)
                    {

                        messages.Add(new Message
                        {

                            type = "text",
                            message = $"hey {users[i].id}",
                            sender_id = users[i].id,
                            reciever_id = users[random.Next(users.Count)].id


                        });


                    }

  



                }

                for(int i = 0; i < 50; i++)
                {
                    for(int j = 0; j < 15; j++)
                    {


                        contacts.Add(new Contact
                        {

                            name = $"user{j}",
                            sender_id = users[i].id,
                            reciever_id = users[random.Next(users.Count)].id


                        });
                    }




                }

                await _appDbContext.users.AddRangeAsync(users);
               await _appDbContext.roles.AddRangeAsync(roles);
                await _appDbContext.contacts.AddRangeAsync(contacts);
                await _appDbContext.messages.AddRangeAsync(messages);
                await _appDbContext.userRoles.AddRangeAsync(userRoles);


                await _appDbContext.SaveChangesAsync();






            }
            catch (Exception ex) {


                throw;
                    }
        }
    }
}
