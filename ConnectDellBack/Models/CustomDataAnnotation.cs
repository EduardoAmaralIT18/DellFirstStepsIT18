using System.ComponentModel.DataAnnotations;
public sealed class IsValidEndDate : ValidationAttribute
    {
        private readonly string StartDatePropertyName;
        //init
        public IsValidEndDate(string StartDatePropertyAttrName)
        {
            this.StartDatePropertyName = StartDatePropertyAttrName;
        }

        //override IsValid
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyTestedInfo = validationContext.ObjectType.GetProperty(this.StartDatePropertyName);
            /// Get Start Date Value 
            var StartDateValue = propertyTestedInfo.GetValue(validationContext.ObjectInstance, null);
            // init start date 
            DateTime StartDate = DateTime.MinValue;
            DateTime EndDate = DateTime.MinValue;

            if (DateTime.TryParse(StartDateValue.ToString(), out StartDate))
            {
                if (DateTime.TryParse(value.ToString(), out EndDate))
                {
                    // Implement your logic
                    if (EndDate >= StartDate)
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult(FormatErrorMessage("End Date Should be after start date"));

                    }

                }

                else
                {
                    return new ValidationResult(FormatErrorMessage("End Date not valid"));

                }
            }
            else
            {
                return new ValidationResult(FormatErrorMessage("Start Date not valid"));
            }
        }
    }