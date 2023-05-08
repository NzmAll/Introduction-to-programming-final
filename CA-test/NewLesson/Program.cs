using NewLesson.Cars;
using NewLesson.Constants;
using System.Globalization;
using System.Numerics;

namespace NewLesson
{
    //public delegate decimal AcceptanceConditionDelegate(int number);
    //public delegate TReturn AcceptanceConditionDelegate<TReturn, TFirstArg>(TFirstArg firstArg);
    //public delegate TReturn AcceptanceConditionDelegate<TReturn, TFirstArg, TSecondArg>(TFirstArg firstArg, TSecondArg secondArg);
    //public delegate TReturn AcceptanceConditionDelegate<TReturn, TFiirstArg, TSecondArg, TThirdArg>(TFirstArg firstArg, TSecondArg secondArg, TThirdArg thirdArg);
    public class Program
    {

        static void Main(string[] args)
        {
            //Sum(new List<int> { 2, 3, 4, 7, 20 }, IsEven);
            //Sum(new List<int> { 2, 3, 4, 7, 20 }, delegate (int number) { return number % 2 == 0; }); //anony  method
            //Sum(new List<int> { 2, 3, 4, 7, 20 }, (int number) => { return number % 2 == 0; });
            //Sum(new List<int> { 2, 3, 4, 7, 20 }, (int number) => number % 2 == 0);
            //Sum(new List<int> { 2, 3, 4, 7, 20 }, (number) => number % 2 == 0);
            //Sum(new List<int> { 2, 3, 4, 7, 20 }, number => number % 2 == 0);
            Sum(new List<int> { 2, 3, 4, 7, 20 }, n => n % 2 == 0); //lambda expression
            Sum(new List<int> { 2, 3, 4, 7, 20 }, n => n % 5 == 0); //lambda expression
        }

        //public static bool IsEven(int number)
        //{
        //    return number % 2 == 0;
        //}


        //Func, Action, Predicate (helper for booleans)
        public static int Sum(List<int> numbers, Func<int, bool> conditionDelegate)
        {
            int sum = 0;

            foreach (int number in numbers)
            {
                if (conditionDelegate(number))
                {
                    sum += number;
                }
            }

            return sum;
        }
    }
}