using JobAppLibrary.Models;
using NUnit.Framework;
using static JobAppLibrary.AppEvaluator;

namespace JobAppLibrary.UnitTest
{
    public class AppEvaluateUnitTest
    {

        [Test]
        public void App_ShouldTransferredToAutoRejected_WithUnderAge()
        {
            var evaluator = new AppEvaluator();
            var form = new JobApp()
            {
                Applicant = new Applicant()
                {
                    Age = 17
                }
            };
            var result = evaluator.Evaluate(form);
            Assert.AreEqual(result, ApplicationResult.AutoAccepted);
            
        }
    }
}