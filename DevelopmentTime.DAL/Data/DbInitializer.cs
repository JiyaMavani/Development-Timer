//using System.Linq;
//using DevelopmentTimer.DAL.Entities;
//using DevelopmentTimer.DAL.Enums;

//namespace DevelopmentTimer.DAL.Data
//{
//    public static class DbInitializer
//    {
//        public static void Seed(AppDbContext context)
//        {
//            if (context.Users.Any())
//                return;

//            var users = new List<User>
//            {
//                new User { Username = "Admin1", Password = "Admin@1234", Role = UserRole.Admin },
//                new User { Username = "Dev1", Password = "Dev@1234", Role = UserRole.Developer },
//                new User { Username = "Dev2", Password = "Dev@5678", Role = UserRole.Developer }
//            };

//            context.Users.AddRange(users);
//            context.SaveChanges();
//        }
//    }
//}
