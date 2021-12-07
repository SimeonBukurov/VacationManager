using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using DataModels;

namespace CRUDOperations
{
    public class UserMenu
    {
         static void CreateUser(ModelContext db)
        {
            Console.Write("User name: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            if (username == " " || password == " ")
            {
                Console.WriteLine("Canceled!");
            }
            else
            {
                Console.Write("Personal Name: ");
                string personalName = Console.ReadLine();
                User user = new User();
                db.Users.Add(user);
                db.SaveChanges();
            }

        }
    }

}
