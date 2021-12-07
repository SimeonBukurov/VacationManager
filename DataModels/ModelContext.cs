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
        public User(string username, string password,string personalname, Role role, Team team)
        {
            Username = username;
            Password = password;
            PersonalName = personalname;
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
        public Role()
        {

        }
        public Role(string name, List<User> user)
        {
            Name = name;
            Users = user;
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
        public Team()
        {

        }
        public Team(string name, string projectname, List<User> developers, User leader)
        {
            ProjectName = projectname;
            Leader = leader;    
            Name = name;
            Developers = developers;
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
        public Vacation()
        {

        }
    }
}