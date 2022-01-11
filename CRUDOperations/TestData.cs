using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
using CRUDOperations;

namespace CRUDOperations
{
    public class TestData
    {
        public void Testing(ModelContext db)
        {
            
            Role role1 = new Role("Developer");
            db.Roles.Add(role1);
            Team team1 = new Team("one", "World of warcraft expansion");   //1st Team, 2nd Project
            db.Teams.Add(team1);

            Role role2 = new Role("Team leader");
            db.Roles.Add(role2);
            Team team2 = new Team("two", "League of legends new mod");   //1st Team, 2nd Project
            db.Teams.Add(team2);

            Role role3 = new Role("CEO");
            db.Roles.Add(role3);
            Team team3 = new Team("three", "Counter-Strike Global Ofensive new granades tactic");  //1st Team, 2nd Project
            db.Teams.Add(team3);

            Role role4 = new Role("Helper");
            db.Roles.Add(role4);
            Team team4 = new Team("forth", "editing and creating objectives");  //1st Team, 2nd Project
            db.Teams.Add(team4);



            User user1 = new User("Coverdrave", "Coviee123", "Plamen", role1, team1);
            db.Users.Add(user1);
            team1.Leader = user1;
            

            User user2 = new User("SwagerStorm", "Seal456", "Simeon", role2, team2);
            db.Users.Add(user2);
            team2.Leader = user2;
            

            User user3 = new User("EzToBan", "Bannies321", "Tolga", role3, team3);
            db.Users.Add(user3);
            team3.Leader = user3;
            

            User user4 = new User("ZedGodnes", "Godds131", "Preslav", role4, team4);
            db.Users.Add(user4);
            team4.Leader = user4;

            Vacation vacation1 = new Vacation(user1, "25.09.21", "20.05.22", "11.01.22");                                     //public Vacation(User submitByUser, string startDate, string endDate, string dateOfCreation)
            db.Vacations.Add(vacation1);

            db.SaveChanges();


        }

    }
}