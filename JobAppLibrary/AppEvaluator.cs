using JobAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAppLibrary
{
    public class AppEvaluator
    {
        private const int minAge = 18;
        private List<string> techStackList = new List<string>() { "C#", "RabbitMq", "MicroService", "Visual Studio" };
        private const int autoAcceptedYearsOfExperince = 15;
        public ApplicationResult Evaluate(JobApp jobApp)
        {
            if (jobApp.Applicant.Age < minAge)
                return ApplicationResult.AutoRejected;

            var sr = GetTechStackSimilarityRate(techStackList);
            if (sr < 25)
                return ApplicationResult.AutoRejected;
            if (sr > 75 && jobApp.YearsOfExperince>=autoAcceptedYearsOfExperince)
                return ApplicationResult.AutoAccepted;
            return ApplicationResult.AutoAccepted;
        }

        private int GetTechStackSimilarityRate(List<string> techStacks)
        {
            var matchedCount = techStacks.Where(i => techStackList.Contains(i, StringComparer.OrdinalIgnoreCase)).Count();
            return (int)((double)matchedCount / techStackList.Count) * 100;
        }

        public enum ApplicationResult
        {
            AutoRejected,
            TransferredToHR,
            TransferredToLead,
            TransferredToCTO,
            AutoAccepted
        }
    }
}
