using NETUA2_Egzaminas.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETUA2_Egzaminas.BLL.Services
{
    public class LevelService : ILevelService
    {
        public SkillInstance CalculateXpCap(SkillInstance skillToCalc)
        {
            throw new NotImplementedException();
        }

        public bool CheckForLevelUp(SkillInstance skillToLevelup)
        {
            if (skillToLevelup == null) return false;
            if (skillToLevelup.Xp >= skillToLevelup.XpCap) return true;
            return false;
        }

        public SkillInstance PerformLevelUp(SkillInstance skillToLevelup)
        {
            throw new NotImplementedException();
        }
    }

    public interface ILevelService
    {
        public bool CheckForLevelUp(SkillInstance skillToLevelup);
        public SkillInstance PerformLevelUp(SkillInstance skillToLevelup);
        public SkillInstance CalculateXpCap(SkillInstance skillToCalc);
    }
}
