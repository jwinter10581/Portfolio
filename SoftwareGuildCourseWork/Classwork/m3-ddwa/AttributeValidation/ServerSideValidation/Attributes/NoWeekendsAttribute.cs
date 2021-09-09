using System;
using System.ComponentModel.DataAnnotations;

namespace ServerSideValidation.Attributes
{
    public class NoWeekendsAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value is DateTime)
            {
                DateTime checkDate = (DateTime)value;

                if (checkDate.DayOfWeek == DayOfWeek.Saturday ||
                    checkDate.DayOfWeek == DayOfWeek.Sunday)
                    return false;
                else
                    return true;
            }

            return false;
        }
    }
}

