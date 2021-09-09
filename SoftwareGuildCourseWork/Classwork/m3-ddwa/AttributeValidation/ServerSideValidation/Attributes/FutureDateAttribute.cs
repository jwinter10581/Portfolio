using System;
using System.ComponentModel.DataAnnotations;

namespace ServerSideValidation.Attributes
{
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime)
            {
                DateTime checkDate = (DateTime)value;
                if (DateTime.Today.AddDays(1) > checkDate)
                    return false;
                else
                    return true;
            }

            return false;
        }
    }
}

