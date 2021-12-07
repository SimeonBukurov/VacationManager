using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;

namespace CRUDOperations
{
    public class UserMenu
    {
        public static void ListUserCommands(ModelContext db)
        {
            Console.WriteLine("1 - Create User");
            Console.WriteLine("2 - Read User");
            Console.WriteLine("3 - Update User");
            Console.WriteLine("4 - Delete User");
            Console.WriteLine();
            Console.Write("Enter your command: ");
            string input = Console.ReadLine();

            int selection = -1;
            if (int.TryParse(input, out selection))
            {
                if (selection == 1)
                {
                    CreateUser(db);
                }
                else if (selection == 2)
                {
                    ReadUser(db);
                }
                else if (selection == 3)
                {
                    UpdateUser(db);
                }
                else if (selection == 4)
                {
                    RemoveUser(db);
                }
            }
        }
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
                string teaminput = Console.ReadLine();                   
                Team teamItem = db.Teams.FirstOrDefault(team => team.Name == teaminput);
                if (teamItem != null)
                {
                    Console.Write("Enter team name to join:");
                    string teamname = Console.ReadLine();
                    teamItem.Name = teamname;
                    db.SaveChanges();
                    Console.WriteLine("Team Joined");
                }
                else
                {
                    Console.WriteLine("Team not found!");
                }
                string roleinput = Console.ReadLine();
                Role roleItem = db.Roles.FirstOrDefault(role => role.Name == roleinput);
                if (roleItem != null)
                {
                    Console.Write("Enter role name to join:");
                    string rolename = Console.ReadLine();
                    roleItem.Name = rolename;
                    db.SaveChanges();
                    Console.WriteLine("Entered Role");
                }
                else
                {
                    Console.WriteLine("Role not found!");
                }
                User user = new User(username, password, personalName, roleItem, teamItem);                  
                db.Users.Add(user);
                db.SaveChanges();
            }

        }
        static void ReadUser(ModelContext db)
        {
             Console.WriteLine("Users:");
             foreach (var user in db.Users)
             {
                 Console.WriteLine(user);
             }

            
        }
        static void UpdateUser(ModelContext db)
        {
            ReadUser(db);
            Console.WriteLine("Select User: ");
            string input = Console.ReadLine();
            User usernameresearch = db.Users.FirstOrDefault(User => User.Username == input);
                if (usernameresearch == null)
                {
                    Console.Write("User Not Found!");
                }
                else
                {
                    Console.Write("Enter new username: ");
                    string name = Console.ReadLine();

                    usernameresearch.Username = name;
                    db.SaveChanges();
                    Console.Write("User Updated!");
                }
            User personalnameresearch = db.Users.FirstOrDefault(User => User.PersonalName == input);
            if (personalnameresearch == null)
            {
                Console.Write("User Not Found!");
            }
            else
            {
                Console.Write("Enter new username: ");
                string name = Console.ReadLine();

                personalnameresearch.Username = name;
                db.SaveChanges();
                Console.Write("User Updated!");
            }
        }
        static void RemoveUser(ModelContext db)
        {
            ReadUser(db);
            Console.Write("Select User: ");
            string input = Console.ReadLine();
                User item = db.Users.FirstOrDefault(user => user.Username == input);
                if (item == null)
                {
                    Console.Write("User Not Found");
                }
                else
                {
                    db.Users.Remove(item);
                    db.SaveChanges();
                    Console.Write("User Removed!");
                }
        }
    }

}
