using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Minerals.Editor.Utils
{
    //TODO: Test this attribute (ValidForAttribute)
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    internal sealed class ValidForAttribute : ValidationAttribute
    {
        private readonly Type[] _types;
        private readonly string _propertyName;

        public ValidForAttribute(string propertyName, params Type[] validTypes)
        {
            _propertyName = propertyName;
            _types = validTypes;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            PropertyInfo property = validationContext.ObjectType.GetProperty(_propertyName)!;
            Type propertyType = property.GetValue(validationContext.ObjectInstance)!.GetType();

            if (value is null || _types.Any(x => x == propertyType))
            {
                return ValidationResult.Success!;
            }

            return new ValidationResult($"Invalid value for type {property.Name}.");
        }
    }
}
