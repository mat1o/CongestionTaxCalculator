using System.ComponentModel.DataAnnotations;

namespace CongestionTaxCalculator.Domain.Annotations
{
    public class DatetimeRangeAnnotation : ValidationAttribute
    {
        public DatetimeRangeAnnotation() { }

        public string GetErrorMessage() => "Year Date must be in 2013/01/01 to 2013/12/30.";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var date = (DateTime)value;

            if (DateTime.Compare(date, new DateTime(2013, 01, 01)) > 0 && DateTime.Compare(date, new DateTime(2013, 12, 31)) < 0)
                return ValidationResult.Success;

            else return new ValidationResult(GetErrorMessage());
        }
    }
}
