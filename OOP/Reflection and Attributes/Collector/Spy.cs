using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldsNames)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] fieldsInfo = classType.GetFields(
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

            StringBuilder sb = new();
            Object classInstance = Activator.CreateInstance(classType, new object[] { });
            sb.AppendLine($"Class under investigation: {className}");
            foreach (FieldInfo field in fieldsInfo.Where(x => fieldsNames.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
            return sb.ToString().Trim();

        }
        public string AnalyzeAccessModifiers(string className)
            {
            Type classType = Type.GetType(className);
            FieldInfo[] fieldsInfo = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] publicMethodInfo = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public );
            MethodInfo[] nonPublicMethodInfo = classType.GetMethods(BindingFlags.Instance|BindingFlags.NonPublic);

            StringBuilder sb = new();
            foreach (FieldInfo field in fieldsInfo)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            foreach (MethodInfo method in nonPublicMethodInfo.Where(x=>x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");

            }
            foreach (MethodInfo method in publicMethodInfo.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");

            }
            return sb.ToString().Trim();

        }

        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);
            MethodInfo[] methodsInfo = classType.GetMethods(BindingFlags.Instance|BindingFlags.NonPublic);
            StringBuilder sb = new();
            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");
            foreach (MethodInfo method in methodsInfo)
            {
                sb.AppendLine(method.Name);
            }
            return sb.ToString().Trim();
        }

        public string CollectGettersAndSetters(string className)
        {
            Type classType = Type.GetType(className);
            MethodInfo[] methodsInfo = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public|BindingFlags.NonPublic);
    
            StringBuilder sb = new();

            foreach (MethodInfo method in methodsInfo.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");

            }
            foreach (MethodInfo method in methodsInfo.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");

            }
            return sb.ToString().Trim();

        }
    }
}
