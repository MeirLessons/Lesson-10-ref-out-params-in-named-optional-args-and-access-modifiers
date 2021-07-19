using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_10_CC_MethodAdv_Access
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Method Advance

            #region Ref Keyword
            int x = 5;
            AddOneToNumberWithRef(ref x);// Value Type
            Console.WriteLine(x);

            SomeClass sc1 = new SomeClass();
            SomeClass sc2 = sc1;
            sc2.name = "ohad";
            ChangeIsOkWithRef(ref sc2);// Reference Type
            #endregion

            #region out Keyword

            int xOut;
            AddOneToNumberWithOut(out xOut);

            SomeClass sc1Out = new SomeClass();
            ChangeIsOkWithOut(out sc1Out);

            string errorMessage;
            if(!InsertToDB("MEIR", 11, out errorMessage))
                Console.WriteLine(errorMessage);
            string input;// = Console.ReadLine();
            int players = 5;
            do
            {
                Console.WriteLine("Please Enter Number: ");
                input = Console.ReadLine();//"43"
            }
            while (!int.TryParse(input, out players));//43

            #endregion

            #region params keyword
            int[] arr = { 2, 4, 6, 8 };
            PrintNumbers(5,8,9);
            CheckKmsByEngine("moshe",120,140,190);
            #endregion

            #region optional params

            //on login
            OnException("bla bla");

            //exception on banner
            OnException("banner problem", false);
            #endregion

            #region named parameters

            bool isPrinted = false;
            GetPersonDetails("dan",13,"male",1.90f, ref isPrinted);
            GetPersonDetails
                (
                gender: "dan",
                age: 13,
                name: "male",
                high: 1.90f,
                printedBefore: ref isPrinted
                );
            GetPersonDetails(printedBefore: ref isPrinted, name: "Shuli", age: 34, gender: "Male", high: 1.81f);

            #endregion

            #endregion

            #region Access Modifiers

            Person p = new Person(25);
            //p.age = 5;//Setter
            //int pAge = p.age;//getter
            Console.WriteLine(p.GetAge());
            p.SetAge(500);
            Console.WriteLine(p.GetAge());
            p.SetAge(31);
            Console.WriteLine(p.GetAge());

            #endregion
        }

        #region Method Advance

        #region named parameters

        public static void GetPersonDetails(in string name, int age, string gender, float high, ref bool printedBefore)
        {
            Console.WriteLine("Name: {0}, Age: {1}, Gender: {2}, High: {3}",name,age,gender,high);
            printedBefore = true;
        }


        #endregion

        #region optional params

        public static void OnException(string error, bool printMessage = true)
        {
            if(printMessage)
                Console.WriteLine(error);
            //InsertToLog(error);
        }

        #endregion

        #region in keyword

        public static void KeepMyValue(in int supVal)// in = readonly. only getter without setter
        {
            //supVal = 3 //It’s Not Possible // Error In Compile Time
           if(supVal == 0);
        }


        #endregion

        #region params keyword

        static void PrintNumbers(params int[] numbers)
        {
            numbers[0] = 10;
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }

        public static void CheckKmsByEngine(string engineType, params int[] kms)
        {
            for (int i = 0; i < kms.Length; i++)
            {
                if(engineType == "Dan")
                {
                    if(kms[i] > 120)
                        Console.WriteLine($"Kms For {i+1} out of range");
                    else
                        Console.WriteLine($"Kms For { i + 1} not out of range");
                }
                if(engineType == "moshe")
                {
                    if (kms[i] > 140)
                        Console.WriteLine($"Kms For {i + 1} out of range");
                    else
                        Console.WriteLine($"Kms For { i + 1} not out of range");
                }

            }
        }


        #endregion

        #region Out Keyword Methods

        static bool InsertToDB(string name, int age,out string errorMessage)
        {
            errorMessage = "";
            if(string.IsNullOrEmpty(name))
            {
                errorMessage = "name is null or empty";
            }
            if(age == 0)
            {
                errorMessage += "\nage is 0";
            }

            return string.IsNullOrEmpty(errorMessage);
        }
        
        static void ChangeIsOkWithOut(out SomeClass someClass)
        {
            SomeClass someClassAher = new SomeClass();
            someClass = new SomeClass();//Must
            someClassAher.isOk = true;
        }
        static void AddOneToNumberWithOut(out int number)
        {
            number = 13;//Must
            string s = "hackeru";
        }

        #endregion

        #region Ref Keyword Methods
        static void ChangeIsOkWithRef(ref SomeClass someClass)
        {
            //someClass = new SomeClass();
            someClass.isOk = true;
        }
        static void AddOneToNumberWithRef(ref int number)
        {
            number = number + 1;
            Console.WriteLine(number);
        }
        #endregion

        #endregion
    }

    public class Person
    {
        private int age;
        protected string name;

        public Person(int age)
        {
            SetAge(age);
        }

        internal Person()
        {

        }

        public int GetAge()
        {
            return this.age;
        }

        public void SetAge(int newAge)
        {
            if(newAge > 0 && newAge <= 120)
                this.age = newAge;
        }


    }
    
    public class Student : Person
    {
        public Student()
        {
            age = 5;
            name = "ben";
        }
    }
    class SomeClass
    {
        public bool isOk;
        public string name;
    }
}
