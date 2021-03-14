using System;
using System.Diagnostics;

namespace ConsoleApp1
{
    public class Test32
    {
 

    public class TestInt32 
    {
        // Start is called before the first frame update
        public  void Start()
        {
            TestNum num  =new TestNum();


            string json = LitJson.JsonMapper.ToJson(num);


            var testNum = LitJson.JsonMapper.ToObject<TestNum>(json);
        
            Console.WriteLine(testNum.a);
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        class TestNum
        {
            public Int32 a;
        }
    }

    }
}