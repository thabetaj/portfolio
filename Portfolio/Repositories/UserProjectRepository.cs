using Portfolio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Repositories
{
    public class UserProjectRepository : IUserProjectRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        public UserProjectRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public List<Project> getAllProjects()
        {
            return applicationDbContext.Projects.ToList();
        }
        public List<Project> getAllProjectsById(string Id)
        {
            return applicationDbContext.Projects
                .Where(x => x.UserId == Id).ToList();
        }
        public Project getProjectById(int Id)
        {
            return applicationDbContext.Projects.Where(x => x.ProjectId == Id).FirstOrDefault();
        }

    }
}
