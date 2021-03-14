using System;
using System.Reflection;

namespace ConsoleApp2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            Type type = typeof(Dog1);//获取
            
            Dog1 dog1 = new Dog1();
            
            DogAttribute? attribute = dog1.GetType().GetCustomAttribute<DogAttribute>();
            
            Console.WriteLine(attribute.Name);
            
            MethodInfo[] methodInfos = type.GetMethods();
            foreach (MethodInfo info in methodInfos)
            {
                DogAttribute? customAttribute = info.GetCustomAttribute<DogAttribute>();
                if (customAttribute!=null)
                {
                    object? invoke = info.Invoke(dog1,new []{"dsfs"});
                }
                
            }
        }
    }

    //[Dog(Name = "狗",Age = 45)]//类特性
    class Dog1
    {
        [Dog("这是一个狗")]
        public void Test(string str)
        {
            Console.WriteLine("我被调用了"+str);
        }
        
    }
}