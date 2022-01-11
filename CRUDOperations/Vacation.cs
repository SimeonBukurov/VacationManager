using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;

namespace CRUDOperations
{
    public class Vacationcommands
    {
        public static void ListVacationCommands(ModelContext db)
        {
            Console.WriteLine("1 - Create an vacation");
            Console.WriteLine("2 - Read vacation");
            Console.WriteLine("3 - Update an vacation");
            Console.WriteLine("4 - Delete an vacation");
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
                    VacationCreate(db);
                }
                else if (condition == 2)
                {
                    VacationRead(db);
                }
                else if (condition == 3)
                {
                    VacationUpdate(db);
                }
                else if (condition == 4)
                {
                    VacationRemove(db);
                }

            }

        }
        static void VacationCreate(ModelContext db)
        {
            Console.Write("Enter the vacation startdate: ");
            string startdate = Console.ReadLine();
            Console.Write("Enter the vacation's enddate: ");
            string enddate = Console.ReadLine();

            if (string.IsNullOrEmpty(startdate) || string.IsNullOrEmpty(enddate))
            {
                Console.WriteLine("Action has been cancelled");

            }
            else
            {

            }

        }

        static void VacationRead(ModelContext db)
        {
            Console.WriteLine("Vacation dates:");
            foreach (var vacations in db.Vacations)
            {
                Console.WriteLine(vacations);
            }

        }

        static void VacationUpdate(ModelContext db)
        {
            VacationRead(db);
            Console.WriteLine();
            Console.Write("Select a vacation: ");
            string input = Console.ReadLine();
            Vacation item = db.Vacations.FirstOrDefault(Vacation => Vacation.StartDate == input);
            if (item == null)
            {
                Console.Write("Vacation not found");
            }
            else
            {
                Console.Write("Enter new vacation: ");
                string name = Console.ReadLine();

                item.StartDate = name;
                db.SaveChanges();
                Console.Write("Vacation Updated!");
            }

        }

        static void VacationRemove(ModelContext db)
        {
            VacationRead(db);
            Console.Write("Select a vacation: ");
            string input = Console.ReadLine();

            Vacation item = db.Vacations.FirstOrDefault(vacation => vacation.StartDate == input);
            if (item == null)
            {
                Console.Write("Vacation Not Found");
            }
            else
            {
                db.Vacations.Remove(item);
                db.SaveChanges();
                Console.Write("Vacation Removed!");
            }

        }
        static Vacation PickVacation(ModelContext db)
        {
            if (db.Vacations.Count() < 1)
            {
                Console.WriteLine("No Vacation!");
                return null;
            }

            Console.WriteLine("Vacations:");
            foreach (var vacation in db.Vacations)
            {
                Console.WriteLine(vacation);
            }
            Console.Write("Select Vacations for the team: ");
            string input = Console.ReadLine();

            while (true)
            {

                {
                    Vacation item = db.Vacations.FirstOrDefault(Vacation => Vacation.DateOfCreation == input);
                    if (item != null)
                    {
                        return item;
                    }
                    Console.WriteLine("Invalid Vacation! Try again.");

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
                foreach (var user in db.Users)
                {
                    Console.WriteLine(user);
                }
                Console.Write("Select User from the team: ");
                string input = Console.ReadLine();

                while (true)
                {
                    {
                        User item = db.Users.FirstOrDefault(User => User.PersonalName == input);
                        if (item != null)
                        {
                            return item;
                        }
                        Console.WriteLine("Invalid User! Try again.");
                    }
                }
            }

            static void AddUserToVacation(ModelContext db)
            {
                Vacation vacation = PickVacation(db);

                while (true)
                {
                    Console.WriteLine("1 - Add User to vacation");
                    Console.WriteLine("2 - Remove User from Vacation");
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
                            if (!vacation.StartDate.Contains(user))
                            {
                                vacation.StartDate.Add(user);
                                db.SaveChanges();
                            }
                        }
                        else if (selection == 2)
                        {
                            User user = PickUser(db);
                            if (!vacation.EndDate.Contains(user))
                            {
                                vacation.EndDate.Remove(user);
                                db.SaveChanges();
                            }
                        }
                    }

                }
            }

        }
    }
}

