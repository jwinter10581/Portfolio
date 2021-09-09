using System.ComponentModel.DataAnnotations;

namespace ServerSideValidation.Attributes
{
    public class MustBeTrueAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value is bool)
            {
                // cast value as bool for returning
                return (bool)value;
            }

            // value is not a bool type, fail
            return false;
        }
    }
}

