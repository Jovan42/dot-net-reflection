using ReflectionTest.Cars;
using System;
using System.Reflection;
using System.Text;

/** URL: https://www.c-sharpcorner.com/UploadFile/keesari_anjaiah/reflection-in-net/ **/
namespace ReflectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Car c = new Car();
            Type t = c.GetType();
            //Type t = Type.GetType("ReflectionTest.Cars.Car", false, false);
            //Type t = typeof(Car);

            //Console.WriteLine(t.FullName);
            //GetTypeProperties(t);

            //GetMethods(t);
            //GetMethod(t);
            //GetMethodsWithFlags(t);

            //GetFields(t);
            //GetProperties(t);
            //GetInterfaces(t);

            //GetParametersInfo(t);

            //GetConstructorInfo(t);


            //AssemblyDemo();


            LateBindingDemo();
            Console.ReadLine();
        }

        private static void LateBindingDemo()
        {
            Assembly assembly;
            assembly = Assembly.GetExecutingAssembly();

            Type type = assembly.GetType("ReflectionTest.Cars.Car");
            object obj = Activator.CreateInstance(type);


            MethodInfo miMoving = type.GetMethod("IsMoving");
            MethodInfo miAccelerate = type.GetMethod("Accelerate");

            object[] speed = new object[] { 20 };
            miAccelerate.Invoke(obj, speed);
            bool isCarMoving = (bool)miMoving.Invoke(obj, null);
            Console.WriteLine("Car is moving : {0}", isCarMoving);

            object[] milesParams = new object[] { 32456, 32810, 10.6 };
            MethodInfo micalculateMPG = type.GetMethod("CalculateMPG");
            double milesPerCallon = (double)micalculateMPG.Invoke(obj, milesParams);
            Console.WriteLine("Miles per gallon is  : {0}", milesPerCallon);
            Console.WriteLine("");
        }

        private static void AssemblyDemo()
        {
            Assembly assembly;
            //assembly = Assembly.Load("mscorlib,2.0.0.0,Neutral,b77a5c561934e089");
            //assembly = Assembly.LoadFrom(@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\caspol.exe");   
            assembly = Assembly.GetExecutingAssembly();

            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
                Console.WriteLine(type.Name);

            Attribute[] attributes = Attribute.GetCustomAttributes(assembly);
            foreach (Attribute attribute in attributes)
                Console.WriteLine(attribute.TypeId);
            Console.WriteLine("");
        }
        private static void GetConstructorInfo(Type t)
        {
            Console.WriteLine("***** ConstructorsInfo *****");
            ConstructorInfo[] ci = t.GetConstructors();
            foreach (ConstructorInfo c in ci)
                Console.WriteLine(c.ToString());
            Console.WriteLine("");
        }

        private static void GetParametersInfo(Type t)
        {
            Console.WriteLine("***** Get Parameters Info *****");
            foreach(MethodInfo m in t.GetMethods())
            {
                string retVal = m.ReturnType.FullName;
                StringBuilder paramInfo = new StringBuilder();
                paramInfo.Append("(");
                foreach (ParameterInfo pi in m.GetParameters())
                    paramInfo.Append(string.Format("{0} {1} ", pi.ParameterType, pi.Name));
                paramInfo.Append(")");
                Console.WriteLine("->{0} {1} {2}", retVal, m.Name, paramInfo);
                Console.WriteLine("");
            }
        }

        private static void GetInterfaces(Type t)
        {
            Type[] ifaces = t.GetInterfaces();
            foreach (Type i in ifaces)
                Console.WriteLine("->{0}", i.Name);
        }

        public static void GetProperties(Type t)
        {
            Console.WriteLine("***** Properties *****");
            PropertyInfo[] pi = t.GetProperties();
            foreach (PropertyInfo prop in pi)
                Console.WriteLine("->{0}", prop.Name);
            Console.WriteLine("");
        }

        public static void GetFields(Type t)
        {
            Console.WriteLine("***** Fields *****");
            FieldInfo[] fi = t.GetFields();
            foreach (FieldInfo field in fi)
                Console.WriteLine("->{0}", field.Name);
            Console.WriteLine("");
        }

        private static void GetMethodsWithFlags(Type t)
        {
            Console.WriteLine("***** Methods *****");
            MethodInfo[] mi = t.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
            foreach (MethodInfo m in mi)
                Console.WriteLine("->{0}", m.Name);
            Console.WriteLine("");
        }

        private static void GetMethod(Type t)
        {
            Console.WriteLine("***** Method IsMoving *****");
            MethodInfo m = t.GetMethod("IsMoving");
            Console.WriteLine("Name: {0}", m.Name);
            Console.WriteLine("Is Public: {0}", m.IsPublic);
            Console.WriteLine("Is Constructor: {0}", m.IsConstructor);

            Console.WriteLine("");
        }

        private static void GetMethods(Type t)
        {
            Console.WriteLine("***** Methods *****");
            MethodInfo[] mi = t.GetMethods();
            foreach (MethodInfo m in mi)
                Console.WriteLine("->{0}", m.Name);
            Console.WriteLine("");
        }

        private static void GetTypeProperties(Type t)
        {
            StringBuilder OutputText = new StringBuilder();
            OutputText.AppendLine("Analysis of type " + t.Name);
            OutputText.AppendLine("Type Name: " + t.Name);
            OutputText.AppendLine("Full Name: " + t.FullName);
            OutputText.AppendLine("Namespace: " + t.Namespace);

            Type tBase = t.BaseType;
            if (tBase != null)
                OutputText.AppendLine("Base Type: " + tBase.Name);

            Type tUnderlyingSystem = t.UnderlyingSystemType;
            if (tUnderlyingSystem != null)
                OutputText.AppendLine("Underlying System Type: " + tUnderlyingSystem.Name);

            OutputText.AppendLine("Is Abstract Class: " + t.IsAbstract);
            OutputText.AppendLine("Is an Arry: " + t.IsArray);
            OutputText.AppendLine("Is a Class: " + t.IsClass);
            OutputText.AppendLine("Is a COM Object : " + t.IsCOMObject);

            OutputText.AppendLine("\nPUBLIC MEMBERS:");
            MemberInfo[] members = t.GetMembers();

            foreach(MemberInfo member in members)
                OutputText.AppendLine(member.DeclaringType + " " + member.MemberType + " " + member.Name);
             
            Console.WriteLine(OutputText);
            Console.WriteLine("");
        }
    }
}
