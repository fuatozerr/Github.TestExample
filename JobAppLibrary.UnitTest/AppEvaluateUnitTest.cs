using JobAppLibrary.Models;
using NUnit.Framework;
using static JobAppLibrary.AppEvaluator;
using Moq;
using JobAppLibrary.Services;

namespace JobAppLibrary.UnitTest
{
    public class AppEvaluateUnitTest
    {

        [Test]
        public void App_ShouldTransferredToAutoRejected_WithUnderAge()
        {
            var evaluator = new AppEvaluator(null);
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
            var mockValidator = new Mock<IIdentityValidator>();

            mockValidator.Setup(i => i.IsValid(It.IsAny<string>())).Returns(true);

            var evaluator = new AppEvaluator(mockValidator.Object);
            var form = new JobApp()
            {
                Applicant = new Applicant()
                {
                    Age = 19,
                    IdentityNumber=""
                },
                TechStackList = new System.Collections.Generic.List<string>() { "" }
            };
            var result = evaluator.Evaluate(form);
            Assert.AreEqual(result, ApplicationResult.AutoRejected);

        }

        [Test]
        public void App_WithNoTechStackOver75P_TransferredToAutAccepted()
        {
            var mockValidator = new Mock<IIdentityValidator>();

            mockValidator.Setup(i => i.IsValid(It.IsAny<string>())).Returns(true);
            var evaluator = new AppEvaluator(mockValidator.Object);
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

        [Test]
        public void App_WithInValidIdentityNumber_TransferToHR()
        {
            var mockValidator = new Mock<IIdentityValidator>(MockBehavior.Strict);

            mockValidator.Setup(i => i.IsValid(It.IsAny<string>())).Returns(false);
            var evaluator = new AppEvaluator(mockValidator.Object);
            var form = new JobApp()
            {
                Applicant = new Applicant()
                {
                    Age = 21
                },
                TechStackList = new System.Collections.Generic.List<string>() { "C#", "RabbitMq", "MicroService", "Visual Studio" },
                YearsOfExperince = 16
            };
            var result = evaluator.Evaluate(form);
            Assert.AreEqual(result, ApplicationResult.TransferredToHR);

        }
    }
}