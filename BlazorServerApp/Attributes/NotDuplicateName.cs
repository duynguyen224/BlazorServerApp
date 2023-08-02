using BlazorServerApp.Context;
using BlazorServerApp.Data.DTO.Request;
using BlazorServerApp.Services;
using System.ComponentModel.DataAnnotations;

namespace BlazorServerApp.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class NotDuplicateName : ValidationAttribute
    {
        public string GetErrorMessage(string name) => $"The department {name} has already exist!";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var department = validationContext.ObjectInstance;
            var departmentService = (IDepartmentService)validationContext.GetService(typeof(IDepartmentService));

            //var isNotValid = true;

            //if (isNotValid)
            //{
            //    return new ValidationResult(GetErrorMessage(department.Name));
            //}
            //else
            //{
            //    return new ValidationResult(GetErrorMessage("JUST KIDDING"));
            //}

            return ValidationResult.Success;
        }
    }
}
