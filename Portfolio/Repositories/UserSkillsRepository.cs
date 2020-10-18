using Portfolio.Data;
using Portfolio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Views.User
{
    public class UserSkillsRepository : IUserSkillsRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        public UserSkillsRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public List<InterpersonalSkills> getAllInterpersonalSkills()
        {
            return applicationDbContext.InterpersonalSkills.ToList();
        }

        public List<InterpersonalSkills> getAllInterPersonalSkillsById(string Id)
        {
            return applicationDbContext.UserInterpersonalSkills
               .Where(x => x.userId == Id).Select(x => x.interpersonalSkills).ToList();
        }

        public List<TechnicalSkills> getAllTechnicalSkills()
        {
            return applicationDbContext.TechnicalSkills.ToList();
        }

        public List<TechnicalSkills> getAllTechnicalSkillsById(string Id)
        {
            return applicationDbContext.UserTechnicalSkills
               .Where(x => x.userId == Id).Select(x => x.technicalSkills).ToList();
        }
        public List<InterpersonalSkills> getAllInterpersonalSkillsShow()
        {
            return applicationDbContext.InterpersonalSkills.ToList();
        }
        public List<TechnicalSkills> getAllTechnicalSkillsShow()
        {
            return applicationDbContext.TechnicalSkills.ToList();
        }

        public void addTechnicalSkill(TechnicalSkills technicalSkills)
        {
            TechnicalSkills technicalSkill = new TechnicalSkills()
            {
                TechnicalSkillName = technicalSkills.TechnicalSkillName,
            };
            applicationDbContext.TechnicalSkills.Add(technicalSkill);
            applicationDbContext.SaveChanges();
        }
        public void RemoveTechnicalSkill(int Id)
        {
            var skill = applicationDbContext.TechnicalSkills.Where(x => x.TechnicalSkillsId == Id).SingleOrDefault();
            applicationDbContext.TechnicalSkills.Remove(skill);
            applicationDbContext.SaveChanges();
        }
        public void RemoveInterpersonalSkill(int Id)
        {
            var skill = applicationDbContext.InterpersonalSkills.Where(x => x.InterpersonalSkillsId == Id).SingleOrDefault();
            applicationDbContext.InterpersonalSkills.Remove(skill);
            applicationDbContext.SaveChanges();
        }
        public void addInterpersonalSkill(InterpersonalSkills interpersonalSkills)
        {
            InterpersonalSkills interpersonalSkill = new InterpersonalSkills()
            {
                InterpersonalSkillName = interpersonalSkills.InterpersonalSkillName,
            };
            applicationDbContext.InterpersonalSkills.Add(interpersonalSkill);
            applicationDbContext.SaveChanges();
        }
        public InterpersonalSkills UpdateInterpersonalSkill(int interpersonalSkillId)
        {
            var interpersonalSkills = applicationDbContext.InterpersonalSkills
                .Where(x => x.InterpersonalSkillsId == interpersonalSkillId).SingleOrDefault();
            InterpersonalSkills interpersonalSkills1 = new InterpersonalSkills
            {
                InterpersonalSkillsId = interpersonalSkills.InterpersonalSkillsId,
                InterpersonalSkillName = interpersonalSkills.InterpersonalSkillName,
            };
            return interpersonalSkills1;
        }
        public void ShowUpdateInterpersonal(InterpersonalSkills interpersonalSkill)
        {
            var interpersonalSkills = applicationDbContext.InterpersonalSkills
                .Where(x => x.InterpersonalSkillsId == interpersonalSkill.InterpersonalSkillsId)
                .SingleOrDefault();
            interpersonalSkills.InterpersonalSkillsId = interpersonalSkill.InterpersonalSkillsId;
            interpersonalSkills.InterpersonalSkillName = interpersonalSkill.InterpersonalSkillName;
            applicationDbContext.SaveChanges();
        }
        public TechnicalSkills UpdateTechnicalSkill(int technicalSkillId)
        {
            var technicalSkills = applicationDbContext.TechnicalSkills
                .Where(x => x.TechnicalSkillsId == technicalSkillId).SingleOrDefault();
            TechnicalSkills technicalSkills1 = new TechnicalSkills
            {
                TechnicalSkillsId = technicalSkills.TechnicalSkillsId,
                TechnicalSkillName = technicalSkills.TechnicalSkillName,
            };
            return technicalSkills1;
        }
        public void ShowUpdateTechnical(TechnicalSkills technicalSkill)
        {
            var technicalSkills  = applicationDbContext.TechnicalSkills
                .Where(x => x.TechnicalSkillsId == technicalSkill.TechnicalSkillsId)
                .SingleOrDefault();
            technicalSkills.TechnicalSkillsId = technicalSkill.TechnicalSkillsId;
            technicalSkills.TechnicalSkillName = technicalSkill.TechnicalSkillName;
            applicationDbContext.SaveChanges();
        }
    }
}
