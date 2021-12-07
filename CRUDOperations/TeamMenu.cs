using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;

namespace CRUDOperations
{
    internal class TeamMenu
    {
        public static void ListTeamCommands(ModelContext db)
        {
            Console.WriteLine("1 - Create Team");
            Console.WriteLine("2 - Read Team");
            Console.WriteLine("3 - Update Team");
            Console.WriteLine("4 - Delete Team");
            Console.WriteLine();
            Console.Write("Enter your command: ");
            string input = Console.ReadLine();

            int selection = -1;
            if (int.TryParse(input, out selection))
            {
                if (selection == 1)
                {
                    CreateTeam(db);
                }
                else if (selection == 2)
                {
                    ReadTeam(db);
                }
                else if (selection == 3)
                {
                    UpdateTeam(db);
                }
                else if (selection == 4)
                {
                    RemoveTeam(db);
                }
            }
        }
        static void CreateTeam(ModelContext db)
        {
            Console.Write("Enter Team name: ");
            string name = Console.ReadLine();
            if (name == null)
            {
                Console.WriteLine("You need to enter team name!!!");
            }
            else
            {
              

            }

        }
        static void ReadTeam(ModelContext db)
        {
            Console.WriteLine("Users:");
            foreach (var user in db.Users)
            {
                Console.WriteLine(user);
            }

        }
        static void UpdateTeam(ModelContext db)
        {
            ReadTeam(db);
            Console.WriteLine("Select User: ");
            string input = Console.ReadLine();
            User item = db.Users.FirstOrDefault(User => User.Username == input);
            if (item == null)
            {
                Console.Write("User Not Found!");
            }
            else
            {
                Console.Write("Enter new username: ");
                string name = Console.ReadLine();

                item.Username = name;
                db.SaveChanges();
                Console.Write("User Updated!");
            }
        }
        static void RemoveTeam(ModelContext db)
        {
            ReadTeam(db);
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
        static Role PickRole(ModelContext db)
        {
            if (db.Roles.Count() < 1)
            {
                Console.WriteLine("No Roles!");
                return null;
            }

            Console.WriteLine("Roles:");
            foreach (var role in db.Roles)
            {
                Console.WriteLine(role);
            }
            Console.Write("Select Roles for User: ");
            string input = Console.ReadLine();

            while (true)
            {

                {
                    Role item = db.Roles.FirstOrDefault(Role => Role.Name == input);
                    if (item != null)
                    {
                        return item;
                    }
                        Console.WriteLine("Invalid Genre! Try again.");
                   
                }
            }
            static  Team PickTeam(ModelContext db)
            {
                if (db.Teams.Count() < 1)
                {
                    Console.WriteLine("No Teams!");
                    return null;
                }

                Console.WriteLine("Books:");
                foreach (var team in db.Teams)
                {
                    Console.WriteLine(team);
                }
                Console.Write("Select Team from the User: ");
                string input = Console.ReadLine();

                while (true)
                {
                    {
                        Team item = db.Teams.FirstOrDefault(Team => Team.Name == input);
                        if (item != null)
                        {
                            return item;
                        }
                            Console.WriteLine("Invalid Book! Try again.");
                    }
                }
                static User PickUser(ModelContext db)
                {
                    if (db.Users.Count() < 1)
                    {
                        Console.WriteLine("No Users!");
                        return null;
                    }

                    Console.WriteLine("Users:");
                    foreach (var users in db.Users)
                    {
                        Console.WriteLine(users);
                    }
                    Console.Write("Select Team to add the User: ");
                    string input = Console.ReadLine();

                    while (true)
                    {

                        User item = db.Users.FirstOrDefault(user => user.Username == input);
                        if (item != null)
                        {
                            return item;
                        }

                            Console.WriteLine("Invalid User! Try again.");

                    }
                }
                static void AddUserToTeam(ModelContext db)
                {
                    Team team = PickTeam(db);

                    while (true)
                    {
                        Console.WriteLine("1 - Add User to Team");
                        Console.WriteLine("2 - Remove User from the Team");
                        Console.WriteLine("0 - Exit");
                        Console.WriteLine();
                        Console.Write("Enter your command: ");
                        string input = Console.ReadLine();

                        int selection = -1;
                        if (int.TryParse(input, out selection))
                        {
                            if (selection == 0)
                            {
                                break;
                            }
                            else if (selection == 1)
                            {
                                User user = PickUser(db);
                                if (!team.Developers.Contains(user))
                                {
                                    team.Developers.Add(user);
                                    db.SaveChanges();
                                }
                            }
                            else if (selection == 2)
                            {
                                User user = PickUser(db);
                                if (!team.Developers.Contains(user))
                                {
                                    team.Developers.Remove(user);
                                    db.SaveChanges();
                                }
                            }
                        }

                    }
                }
            }
        }
    }
}
