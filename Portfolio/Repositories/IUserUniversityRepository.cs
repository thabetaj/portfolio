using Portfolio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Repositories
{
    public interface IUserUniversityRepository
    {
        public List<University> getAllUniversities();
        public List<Degree> getAllDegrees();
        public List<UserUniversity> getAllUniversitiesById(string Id);
        public List<University> getAllUniversitiesEdit();
        public void remove(int Id);
        public void add(University university);
        public University UpdateUniversity(int UniversityId);
        void Showupdate(University university);
    }
}
