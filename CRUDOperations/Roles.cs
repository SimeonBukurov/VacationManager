using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;

namespace CRUDOperations
{
    public class Roles
    {
        public static void PrintArtistCommands(ModelContext db)
        {
            Console.WriteLine("1 - Create an role");
            Console.WriteLine("2 - Read role");
            Console.WriteLine("3 - Update an role");
            Console.WriteLine("4 - Delete an role");
            Console.WriteLine("0 - Exit");
            Console.WriteLine();
            Console.Write("Enter a command: ");
            string input = Console.ReadLine();
            Console.WriteLine();

            int condition = -1;
            if (int.TryParse(input, out condition))
            {
                if (condition == 1)
                {
                    RoleCreate(db);
                }
                else if (condition == 2)
                {
                    RoleRead(db);
                }
                else if (condition == 3)
                {
                    RoleUpdate(db);
                }
                else if (condition == 4)
                {
                    RoleRemove(db);
                }
            }
        }

        static void RoleCreate(ModelContext db)
        {
            Console.Write("Enter the role's name: ");
            string name = Console.ReadLine();

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Action has been cancelled.");
            }
            else
            {
                Role role = new Role();
                role.Name = name;
                role.Users = new List<User>();
                db.Roles.Add(role);
                try
                {
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    throw raise;
                }
                Console.WriteLine();
                Console.WriteLine("The role has been added.");
            }
        }

        public static void RoleRead(ModelContext db)
        {
            Console.WriteLine("Roles:");
            foreach (var roles in db.Roles)
            {
                Console.WriteLine(roles);
            }
        }

   
        static void RoleUpdate(ModelContext db)
        {
            RoleRead(db);
            Console.WriteLine();
            Console.Write("Select an role: ");
            string input = Console.ReadLine();

            Role item = db.Roles.FirstOrDefault(role => role.Name == input);
            if (item == null)
            {
                Console.Write("The selected role could not be found.");
            }
            else
            {
                Console.Write("Enter the role's new name: ");
                string name = Console.ReadLine();

                item.Name = name;
                db.SaveChanges();
                Console.Write("The role has been successfully updated.");
            }
        }

        //Премахва избран артист
        static void RoleRemove(ModelContext db)
        {
            RoleRead(db);
            Console.WriteLine();
            Console.Write("Select an role: ");
            string input = Console.ReadLine();

            Role item = db.Roles.FirstOrDefault(role => role.Name == input);
            if (item == null)
            {
                Console.Write("The selected role could not be found.");
            }
            else
            {
                db.Roles.Remove(item);
                db.SaveChanges();
                Console.Write("The role has been successfully removed.");
            }
        }
    }

}

