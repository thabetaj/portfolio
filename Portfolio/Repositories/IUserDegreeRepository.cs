using Portfolio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Repositories
{
    public interface IUserDegreeRepository
    {
        public void remove(int Id);
        public void add(Degree degree);
        public List<Degree> getAllDegrees();
        public void ShowUpdate(Degree degree);
        public Degree UpdateDegree(int degreeId);

    }
}
