using System.ComponentModel.DataAnnotations;

namespace SabrinaRoleApp.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? Tier { get; set; }
        public bool IsActive { get; set; }

        // Navigation property for the Users table
        public ICollection<User> Users { get; set; }

        //public ICollection<JobLink> NextJobLinks { get; set; }

        public ICollection<Job> NextJobs { get; set; }

        public Job()
        {
            //fill in later 
        }
    }
}
