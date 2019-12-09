using System;
using System.Collections.Generic;


namespace SimpleCulc
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            string number = "//[**][^^]\n10**9999^^-5";
            try
            {
               int result = calculator.Calculating(number);
               Console.WriteLine($"Сумма элементов ={result}");
            }
            catch (Exception ex)
            {            
                Console.WriteLine("{0}", ex.Message);             
            }
        }
                       
        class Calculator
        {
            int result;
            public int Result { get => result;
                set 
                {
                    if (value > 1000)
                       result = 0;
                    else
                        result = value;

                }
            }
            public int Calculating(string number)
            {
                var delimeters = new List<string> { ",", @"\n", ";" };

                Result = 0;

                int sumNumbers = 0;
                number = Sort(number, delimeters);
                string[] numbers = SplitSort(number, delimeters);

                sumNumbers = Convert(sumNumbers, numbers);                
                return sumNumbers;
            }

            private int Convert(int sumNumbers, string[] numbers)
            {
                foreach (string value in numbers)
                {
                    Result = System.Convert.ToInt32(value);
                    if (Result < 0)
                    {
                        Console.WriteLine("{0}", Result);
                        throw new Exception("Сложение отрицательных чисел недопустимо");                                        
                    }
                    else
                        sumNumbers += Result;
                }
                return sumNumbers;
            }

            private static string[] SplitSort(string number, List<string> delimeters)
            {
                return number.Split(delimeters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            }

            private string Sort(string number, List<string> delimeters)
            {
                if (number.StartsWith("//"))
                {                
                    string s = String.Concat(number[3], number[4]);
                    string s2 = String.Concat(number[7], number[8]);
                    delimeters.Add(s);
                    delimeters.Add(s2);
                    number = number.Substring(10);
                }

                return number;
            }
                   
        }
    }
       
}

 