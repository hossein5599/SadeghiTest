using Microsoft.EntityFrameworkCore;
using SadeghiTest.Models;
namespace SadeghiTest
{
    public class DbInitializer
    {
        public static void Initialize(SadeghiDbContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();
            if (dbContext.MyModels.Any()) return; var models = new List<MyModel>();
            for (int i = 0; i < 400; i++)           
                {
                Random random1 = new Random();
                byte randomByte = (byte)random1.Next(0, 2);

                Random random2 = new Random();
                int randomNumber = random2.Next(1, 4); 
                long randomLong = (long)randomNumber; 

                MyModel model = new MyModel
                { Serial = i + 1, AccNum = 123456 + i, Title = "Title " + i.ToString(), Active = randomByte, DLTyperef = randomLong, Dsr = "Dsr "+i.ToString() };
                dbContext.MyModels.Add(model);
            }
            dbContext.SaveChanges();
            
            var types = new List<DLType> {
                
                new DLType { Id = 1, Name = "پرسنل" }, 
                
                new DLType { Id = 2, Name = "شخص حقیقی" },
                
                new DLType { Id = 3, Name = "شخص حقوقی" } };
            
            foreach (var type in types) dbContext.DLTypes.Add(type);
            
            dbContext.SaveChanges();
        }
    }
}
