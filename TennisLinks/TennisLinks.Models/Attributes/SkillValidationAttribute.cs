using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TennisLinks.Models.Attributes
{
    [AttributeUsage(
        AttributeTargets.Field | AttributeTargets.Property,
        AllowMultiple = false,
        Inherited = true)]
    class SkillValidationAttribute : ValidationAttribute
    {
        private double[] skillLevels = { 1.0, 1.5, 2.0, 2.5, 3.0, 3.5, 4.0, 4.5, 5.0, 5.5, 6.0, 7.0 };

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            if (!skillLevels.Contains((double)value))
            {
                return false;
            }

            return true;
        }
    }
}
