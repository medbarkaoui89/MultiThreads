//using System;

//namespace MyProject
//{
//    // Attributes go ABOVE the class
//    [Serializable]
//    class Program
//    {
//        // Attributes go ABOVE fields/variables
//        static int globalCount = 0;

//        // Attributes go ABOVE the method
//        [Obsolete("Use NewMethod instead")]
//        static void OldMethod()
//        {
//            Console.WriteLine("This is an old method.");
//        }

//        static void Main(string[] args)
//        {
//            // ERROR CAUSE: You cannot put [Attributes] here inside Main!
//            int localVariable = 10;

//            Console.WriteLine("Hello World!");
//            OldMethod();
//        }
//    }
//}