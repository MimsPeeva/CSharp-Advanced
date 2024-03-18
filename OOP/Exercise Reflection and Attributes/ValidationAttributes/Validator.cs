using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] propInfo = type.GetProperties();
            PropertyInfo[] propCustomAttr = propInfo.
                Where(p=>Attribute.IsDefined(p, typeof(MyValidationAttribute), inherit:true))
                .ToArray();
            foreach (PropertyInfo prop in propCustomAttr)
            {
                    var validationAttr = prop.GetCustomAttributes(typeof(MyValidationAttribute), inherit: true)
                    .Cast<MyValidationAttribute>() ;
                Console.WriteLine(prop.Name);
            foreach (var attr in validationAttr)
            {
                object value = prop.GetValue(obj);
                    if (attr.IsValid(value)==false)
                    {
                        return false;
                    }
            }
            }
            return true;
        }
    }
}
