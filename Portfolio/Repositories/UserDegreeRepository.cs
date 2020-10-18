using Portfolio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Repositories
{
    public class UserDegreeRepository : IUserDegreeRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        public UserDegreeRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public List<Degree> getAllDegrees()
        {
            return applicationDbContext.Degrees.ToList();
        }

        public void add(Degree degree)
        {
            Degree degree1 = new Degree()
            {
                DegreeName = degree.DegreeName,
            };
            applicationDbContext.Degrees.Add(degree1);
            applicationDbContext.SaveChanges();
        }

        public void remove(int Id)
        {
            var degree = applicationDbContext.Degrees.Where(x => x.DegreeId == Id).SingleOrDefault();
            applicationDbContext.Degrees.Remove(degree);
            applicationDbContext.SaveChanges();
        }
        public Degree UpdateDegree(int degreeId)
        {
            var degrees = applicationDbContext.Degrees
                .Where(x => x.DegreeId == degreeId).SingleOrDefault();
            Degree degree = new Degree
            {
                DegreeId = degrees.DegreeId,
                DegreeName = degrees.DegreeName,
            };
            return degree;
        }
        public void ShowUpdate(Degree degree)
        {
            var degrees = applicationDbContext.Degrees
                .Where(x => x.DegreeId == degree.DegreeId)
                .SingleOrDefault();
            degrees.DegreeId = degree.DegreeId;
            degrees.DegreeName = degree.DegreeName;
            applicationDbContext.SaveChanges();
        }
    }
}
