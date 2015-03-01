using System;
using System.Linq;
using FluentValidation;
using NUnit.Framework;
using Pipeline;
using Risk.Api._Api.Personal;
using StructureMap;

namespace Tests.Validation
{
    [TestFixture]
    public class update_personal
    {
        private IContainer _container;

        [SetUp]
        public void Setup()
        {
            _container = new Container(cfg =>
            {
                var pipline = new PipeLineRegistry(typeof(UpdatePersonal).Assembly);
                cfg.AddRegistry(pipline);
            }); 
        }

        [Test]
        public void first_name_is_required()
        {
            var validator = _container.GetInstance<IValidator<UpdatePersonal>>();
            var updatePersonal = new UpdatePersonal
            {
                Surname = "dd", Dob = DateTime.Now
            };
            var validationResult = validator.Validate(updatePersonal);

            Assert.That(validationResult.IsValid, Is.EqualTo(false));
            Assert.That(validationResult.Errors.Count, Is.EqualTo(1));
            Assert.That(validationResult.Errors.First().PropertyName, Is.EqualTo("firstName"));
        }
    }
}
