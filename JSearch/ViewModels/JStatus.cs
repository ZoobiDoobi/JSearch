using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JSearch.ViewModels
{
    public class JStatus : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }
            var val = Convert.ToInt32(value);
            if (val == 0 || val == 1)
            {
                return true;
            }
            return false;
        }
    }
}