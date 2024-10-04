using System;
using System.Reflection;

namespace ReflectionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the type of the object to reflect
            Type myType = typeof(MyClass);

            // Get the properties of the type
            PropertyInfo[] properties = myType.GetProperties();
            Console.WriteLine("Properties:");
            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine($"  {property.Name} ({property.PropertyType})");
            }

            // Get the methods of the type
            MethodInfo[] methods = myType.GetMethods();
            Console.WriteLine("\nMethods:");
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine($"  {method.Name} ({method.ReturnType})");
            }

            // Create an instance of the type
            object myObject = Activator.CreateInstance(myType);

            // Set a property value using reflection
            PropertyInfo myProperty = myType.GetProperty("MyProperty");
            myProperty.SetValue(myObject, "Hello, world!");

            // Get the property value using reflection
            string propertyValue = (string)myProperty.GetValue(myObject);
            Console.WriteLine("\nProperty value: " + propertyValue);

            // Call a method using reflection
            MethodInfo myMethod = myType.GetMethod("MyMethod");
            myMethod.Invoke(myObject, null);
        }
    }

    class MyClass
    {
        public string MyProperty { get; set; }

        public void MyMethod()
        {
            Console.WriteLine("MyMethod called");
        }
    }
}