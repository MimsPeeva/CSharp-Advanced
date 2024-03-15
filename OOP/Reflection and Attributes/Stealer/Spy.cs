using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string [] fieldsNames)
        {
           Type classType = Type.GetType(className);
            FieldInfo[] fieldsInfo = classType.GetFields(
                BindingFlags.Instance|BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Static);

            StringBuilder sb = new();
            Object classInstance = Activator.CreateInstance(classType, new object[] { });
            sb.AppendLine($"Class under investigation: {className}");
            foreach (FieldInfo field in fieldsInfo.Where(x=>fieldsNames.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
            return sb.ToString().Trim();
        }
    }
}
