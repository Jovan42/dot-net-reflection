using ReflectionTest.Cars;
using System;
using System.Reflection;
using System.Text;

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
            Console.ReadLine();
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
            MemberInfo[] Members = t.GetMembers();

            foreach(MemberInfo Member in Members)
                OutputText.AppendLine(Member.DeclaringType + " " + Member.MemberType + " " + Member.Name);
             
            Console.WriteLine(OutputText);
        }
    }
}
