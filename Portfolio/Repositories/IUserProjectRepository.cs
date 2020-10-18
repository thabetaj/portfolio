using Portfolio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Repositories
{
    public interface IUserProjectRepository
    {
        public List<Project> getAllProjects();
        public List<Project> getAllProjectsById(string Id);
        public Project getProjectById(int Id);

    }
}
