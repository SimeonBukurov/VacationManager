using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace DataModels
{
    public class ModelContext : DbContext
    {
        public ModelContext()
            : base("name=DataModelContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Vacation> Vacations { get; set; }
    }

    public class User
    {
        [Key, Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PersonalName { get; set; }
        [Required]
        public virtual Role Role { get; set; }
        [Required]
        public virtual Team Team { get; set; }
        public User(string username, string password,string personalName, Role role, Team team)
        {
            Username = username;
            Password = password;
            PersonalName = personalName;
            this.Role = role;
            this.Team = team;
        }
        public User()
        {

        }
    }

    public class Role
    {
        [Key, Required]
        public string Name { get; set; }
        [Required]
        public virtual List<User> Users { get; set; }
        public Role(string name, User user)
        {
            Name = name;
            Users.Add(user);
        }
        public Role()
        {

        }
    }

    public class Team
    {
        [Key, Required]
        public string Name { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public virtual List<User> Developers { get; set; }
        [Required]
        public virtual User Leader { get; set; }
        public Team(string name, string projectName, List<User> developers, User leader)
        {
            Name = name;
            ProjectName = projectName;
            Developers = developers;
            Leader = leader;
        }
        public Team()
        {

        }
    }

    public class Vacation
    {
        [Key, Required]
        public virtual User SubmitByUser { get; set; }
        [Required]
        public string StartDate { get; set; }
        [Required]
        public string EndDate { get; set; }
        [Required]
        public string DateOfCreation { get; set; }
        public bool IsApproved { get; set; }
        public Vacation(User submitByUser, string startDate, string endDate, string dateOfCreation, bool isApproved)
        {
            SubmitByUser = submitByUser;
            StartDate = startDate;
            EndDate = endDate;
            DateOfCreation = dateOfCreation;
            IsApproved = isApproved;
        }
        public Vacation()
        {

        }
    }
}