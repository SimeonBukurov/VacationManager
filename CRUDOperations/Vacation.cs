using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;

namespace CRUDOperations
{
    public class Vacation
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
                Vacation vacation = new Vacation();
                vacation.SubmitByUser = (db);
                vacation.StartDate = startdate;
                vacation.EndDate = enddate;
                vacation.DateOfCreation = dateofcreation;
                vacation.IsApproved = isapproved;

                db.Vacations.Add(vacation);
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
                Console.WriteLine("The vacation date has been added.");
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
        
        //static void VacationUpdate(ModelContext db)
        //{
        //    VacationRead(db);
        //    Console.WriteLine();
        //    Console.Write("Select a vacation: ");
        //    string input = Console.ReadLine();

          
        //}
        
       //static void VacationRemove(ModelContext db)
       // {
       //     VacationRead(db);
       //     //Console.WriteLine();
       //     Console.Write("Select a vacation: ");
       //     string input = Console.ReadLine();

       //     Vacation item = db.Vacations.FirstOrDefault(vacation => vacation.StartDate == input);
       //     if (item == null)
       //     {
       //         Console.Write("The selected vacation could not be found.");
       //     }
       // }

    }

}

