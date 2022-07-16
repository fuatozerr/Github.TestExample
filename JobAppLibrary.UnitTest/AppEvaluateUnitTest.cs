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
            Assert.AreEqual(result, ApplicationResult.AutoRejected);

        }

        [Test]
        public void App_WithNoTechStack_TransferredToAutoRejected()
        {
            var evaluator = new AppEvaluator();
            var form = new JobApp()
            {
                Applicant = new Applicant()
                {
                    Age = 17
                },
                TechStackList = new System.Collections.Generic.List<string>() { "s" }
            };
            var result = evaluator.Evaluate(form);
            Assert.AreEqual(result, ApplicationResult.AutoRejected);

        }

        [Test]
        public void App_WithNoTechStackOver75P_TransferredToAutAccepted()
        {
            var evaluator = new AppEvaluator();
            var form = new JobApp()
            {
                Applicant = new Applicant()
                {
                    Age = 21
                },
                TechStackList = new System.Collections.Generic.List<string>() { "C#", "RabbitMq", "MicroService", "Visual Studio" },
                YearsOfExperince=16
            };
            var result = evaluator.Evaluate(form);
            Assert.AreEqual(result, ApplicationResult.AutoAccepted);

        }
    }
}