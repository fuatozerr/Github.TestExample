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
        public ApplicationResult Evaluate(JobApp jobApp)
        {
            if (jobApp.Applicant.Age < minAge)
                return ApplicationResult.AutoRejected;
            return ApplicationResult.AutoAccepted;
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
