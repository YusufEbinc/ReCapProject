using Castle.DynamicProxy;
using Core.CrossCuttingConserns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspectAttribute : MethodInterceptionAttribute
    {
        private readonly Type _validatorType;
        // Attribute lara tipler type ile atanır 
        // burda bir yapıcı metodunda validator tip gelmesi lazım
        public ValidationAspectAttribute(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception("bu bir doğrulama değil");
            }

            _validatorType = validatorType;
        }

       
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            // metottan önce çalışarak bir reflection ile (28 st) validor instance oluşturur (carVAlidator) run time de ama

            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //validator tipini bulur <car> 
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            // ilgili metodun (invocation) parametlerini bulur ve tek tek validate eder
            foreach (var entity in entities)
            { 
                ValidationTool.Validate(validator, entity);
               
            }
        }
    }
}
