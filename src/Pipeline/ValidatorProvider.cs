using System.Collections.Generic;
using FluentValidation;
using StructureMap;

namespace Pipeline
{
    public class ValidatorProvider
    {
        private readonly IContainer _container;

        public ValidatorProvider(IContainer container)
        {
            _container = container;
        }

        public IEnumerable<IValidator<T>> For<T>()
        {
            var validators = _container.GetAllInstances<IValidator<T>>();
            return validators;
        } 
    }
}