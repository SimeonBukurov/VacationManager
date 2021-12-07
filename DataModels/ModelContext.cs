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
    }

    public class Role
    {
        [Key, Required]
        public string Name { get; set; }
        [Required]
        public virtual List<User> Users { get; set; }
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
    }
}