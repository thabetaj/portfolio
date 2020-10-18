using Portfolio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Repositories
{
    public interface IUserSkillsRepository
    {
        public List<TechnicalSkills> getAllTechnicalSkills();
        public List<InterpersonalSkills> getAllInterpersonalSkills();
        public List<TechnicalSkills> getAllTechnicalSkillsById(string Id);
        public List<InterpersonalSkills> getAllInterPersonalSkillsById(string Id);
        public List<InterpersonalSkills> getAllInterpersonalSkillsShow();
        public List<TechnicalSkills> getAllTechnicalSkillsShow();
        public void addTechnicalSkill(TechnicalSkills technicalSkills);
        public void addInterpersonalSkill(InterpersonalSkills interpersonalSkills);
        public void RemoveTechnicalSkill(int Id);
        public void RemoveInterpersonalSkill(int Id);
        public InterpersonalSkills UpdateInterpersonalSkill(int interpersonalSkill);
        public void ShowUpdateInterpersonal(InterpersonalSkills interpersonalSkill);
        public TechnicalSkills UpdateTechnicalSkill(int technicalSkillId);
        public void ShowUpdateTechnical(TechnicalSkills technicalSkill);
    }
}
