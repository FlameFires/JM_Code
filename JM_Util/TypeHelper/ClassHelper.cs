using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JM_Util.TypeHelper
{
    public class ClassHelper
    {
        public static Form GetForm(string className, params object[] paras)
        {
            return GetObject<Form>(className, paras);
        }

        public static object GetObject(string className, params object[] paras)
        {
            return GetObject<object>(className, paras);
        }

        public static T GetObject<T>(string className, params object[] paras)
            where T : class
        {
            System.Type type = GetType(className);
            if (type == null)
            {
                return null;
            }
            List<System.Type> paraTypes = new List<System.Type>();
            for (int i = 0; i < paras.Length; i++)
            {
                object para = paras[i];
                if (para == null)
                {
                    throw new Exception("利用构造函数生成类时，参数不能为null");
                }
                System.Type pt = para.GetType();
                paraTypes.Add(pt);
            }
            ConstructorInfo ci = type.GetConstructor(paraTypes.ToArray());
            object obj = ci.Invoke(paras);
            return obj as T;
        }

        public static System.Type GetType(string vClassName)
        {
            string vAssembly = string.Empty;
            if (vClassName.IndexOf(',') > -1)
            {
                string[] collection = vClassName.Split(new char[]
				{
					','
				});
                List<string> list = new List<string>();
                list.AddRange(collection);
                vClassName = list[0];
                list.RemoveAt(0);
                string text = string.Join(",", list.ToArray()).Trim();
                vAssembly = text;
                if (text.ToLower().EndsWith(".dll"))
                {
                }
                else
                {
                    vAssembly = text;
                }
            }
            vClassName = vClassName.Trim();

            Assembly ass = GetAssemble(vAssembly);

            return GetType(ass, vClassName);
        }


        public static System.Type GetType(Assembly vAssembly, string vTypeName)
        {
            if (string.IsNullOrEmpty(vTypeName))
            {
                return null;
            }
            vTypeName = vTypeName.Trim();
            System.Type type = vAssembly.GetType(vTypeName);
            if (type == null)
            {
                throw new Exception(string.Concat(new string[]
				{
					"[",
					vAssembly.FullName,
					"]中不存在类[",
					vTypeName,
					"]"
				}));
            }
            return type;
        }

        public static Assembly GetAssemble(string vAssembly)
        {
            if (string.IsNullOrEmpty(vAssembly))
            {
                return GetDefaultAssemble();
            }
            else if (vAssembly.ToLower().Trim().EndsWith(".dll"))
            {
                return GetAssembleWithDll(vAssembly);
            }
            else
            {
                return GetAssembleWithAssembly(vAssembly);
            }
        }

        public static Assembly GetAssembleWithDll(string vDll)
        {
            if (string.IsNullOrEmpty(vDll))
            {
                return GetDefaultAssemble();
            }
            vDll = vDll.Trim();
            Assembly assembly = Assembly.LoadFrom(vDll);
            if (assembly == null)
            {
                throw new Exception("程序集[" + vDll + "]不存在!");
            }
            return assembly;
        }

        public static Assembly GetAssembleWithAssembly(string vAssemblyName)
        {
            if (string.IsNullOrEmpty(vAssemblyName))
            {
                return GetDefaultAssemble();
            }
            vAssemblyName = vAssemblyName.Trim();
            Assembly assembly = Assembly.Load(vAssemblyName);
            if (assembly == null)
            {
                throw new Exception("命名空间[" + vAssemblyName + "]不存在!");
            }
            return assembly;
        }

        private static Assembly GetDefaultAssemble()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}
