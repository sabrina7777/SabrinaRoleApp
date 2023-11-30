using SabrinaRoleApp.Models;

namespace SabrinaRoleApp.Data
{
    public class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Create all of the jobs up front:
            List<Job> jobs = new List<Job>
        {
            new Job
            {
                Title = "CEO",
                Description = "He's the CEO, man.",
                IsActive = true
            },
            new Job()
            {
                Title = "Regional Manager",
                Description = "Something like Michael Scott",
                IsActive = true
            },
            new Job()
            {
                Title = "Assistant to the Regional Manager",
                Description = "Dwight Schrute",
                IsActive = true
            },
            new Job()
            {
                Title = "Custodian",
                Description = "Is Custodian",
                IsActive = true
            },
            new Job()
            {
                Title = "Software Engineer",
                Description = "Code Monkey",
                IsActive = true
            }
        };

            context.Jobs.AddRange(jobs);
            // Make all of the jobs.
            context.SaveChanges();

            Dictionary<string, Job> jobsDict = jobs.ToDictionary(j => j.Title, j => j);

            // Setup the connections however you'd like.
            jobsDict["Regional Manager"].NextJobs.Add(jobsDict["CEO"]);
            jobsDict["Assistant to the Regional Manager"].NextJobs.Add(jobsDict["Regional Manager"]);
            jobsDict["Assistant to the Regional Manager"].NextJobs.Add(jobsDict["Software Engineer"]);
            jobsDict["Custodian"].NextJobs.Add(jobsDict["Software Engineer"]);
            jobsDict["Custodian"].NextJobs.Add(jobsDict["Assistant to the Regional Manager"]);

            context.Jobs.UpdateRange(jobsDict.Values);
            context.SaveChanges();
        }
    }
}