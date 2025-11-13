using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Utils;

public static class Validator
{
    public static bool IsValid(object obj)
    {
        Type objType = obj.GetType();

        PropertyInfo[] properties = objType.GetProperties();

        foreach (PropertyInfo property in properties)
        {
            IEnumerable<MyValidationAttribute> validationAttributes = property.GetCustomAttributes<MyValidationAttribute>();

            foreach (MyValidationAttribute attribute in validationAttributes)
            {
                object value = property.GetValue(obj);

                if (!attribute.IsValid(value))
                {
                    return false;
                }
            }
        }

        return true;
    }
}
