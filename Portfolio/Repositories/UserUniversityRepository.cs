using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Repositories
{
    public class UserUniversityRepository : IUserUniversityRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        public UserUniversityRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public List<Degree> getAllDegrees()
        {
            return applicationDbContext.Degrees.ToList();
        }

        public List<University> getAllUniversities()
        {
            return applicationDbContext.Universities.ToList();
        }
        public List<University> getAllUniversitiesEdit()
        {
            return applicationDbContext.Universities.ToList();
        }
        public List<UserUniversity> getAllUniversitiesById(string Id) 
        {
            return applicationDbContext.UserUniversitiess
                .Where(x => x.UserId == Id).ToList();
        }
        public void remove(int Id)
        {
            var university = applicationDbContext.Universities.Where(x => x.UniversityId == Id).SingleOrDefault();
            applicationDbContext.Universities.Remove(university);
            applicationDbContext.SaveChanges();
        }
        public void add(University university)
        {
            University university1 = new University()
            {
                UniversityName = university.UniversityName,
            };
            applicationDbContext.Universities.Add(university1);
            applicationDbContext.SaveChanges();
        }
        
        public University UpdateUniversity(int uniId)
        {
            var university = applicationDbContext.Universities.Where(x => x.UniversityId == uniId).SingleOrDefault();
            University university1 = new University
            {
                UniversityId = university.UniversityId,
                UniversityName = university.UniversityName,
            };
            return university1;
        }
        public void Showupdate(University university)
        {
            var university1 = applicationDbContext.Universities.Where(x => x.UniversityId == university.UniversityId).SingleOrDefault();
            university1.UniversityId = university.UniversityId;
            university1.UniversityName = university.UniversityName;
            applicationDbContext.SaveChanges();
        }
    }
}
