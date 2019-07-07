using System;

namespace CSharpSix
{
    class Program
    {        
        static void Main(string[] args)
        {
            NullConditionalOperators();
            NullCoalescing();
            NullConditionalArray();

            StringInterpolation();
            StringInterpolationConditionalOperator();

            ExpressionBodiedFunctionMembers();

            Console.ReadLine();
        }

        private static void ExpressionBodiedFunctionMembers()
        {
            Person person = new Person();

            //old way property
            Console.WriteLine(person.MyName);

            //new way property
            Console.WriteLine(person.MyCatsName);

            //old way method
            Console.WriteLine(OldSum(1, 2).ToString());

            //new way method
            Console.WriteLine(NewSum(2, 3).ToString());
        }

        private static int OldSum(int x, int y)
        {
            return x + y;
        }

        private static int NewSum(int x, int y) => x + y;

        private static void StringInterpolationConditionalOperator()
        {
            Person christina = new Person("Christina", "Porter", new DateTime(1984, 6, 26));
            int age = DateTime.Now.Year - christina.Birthday.Year;

            Console.WriteLine($"{christina.FirstName} is {age} years {(age < 58 ? "young" : "old")}.");
        }

        private static void StringInterpolation()
        {
            Person christina = new Person("Christina", "Porter", new DateTime(1984, 6, 26));
            
            //Before
            Console.WriteLine("Composite Formatting");
            Console.WriteLine("Hello {0} {1}!", christina.FirstName, christina.LastName);
            
            // After
            Console.WriteLine("String Interpolation");
            Console.WriteLine($"Hello {christina.FirstName} {christina.LastName}!");
        }

        private static void NullConditionalArray()
        {
            String[] array = null;
            var fourth = array?[1];
        }

        private static void NullCoalescing()
        {
            Person person = null;
            var first = person?.FirstName ?? "Unspecified";
            Console.WriteLine(first);
        }

        private static void NullConditionalOperators()
        {
            Person person = null;
            //var s = person.FirstName; --Without Null Check throws exception

            //Before
            string firstName;
            if (person != null)
                firstName = person.FirstName;

            //After
            //Short circuits if person is null and returns null;
            var first = person?.FirstName;

            Console.WriteLine(first);
        }
    }
}
