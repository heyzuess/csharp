using System;

namespace myApp {
    class myApp {
        static public bool checkDiv (string x) {
            double sum = 0;
            bool returnVal = false;
            
            for (int i = 0; i < x.Length; i++) {
                sum +=  Char.GetNumericValue(x[i]);
            }

            Console.WriteLine("Sum of digits: {0}", sum);
            returnVal = sum % 9 == 0;

            return returnVal;
        }

        static void Main(string[] args) {
            while (true) {
                Console.WriteLine("\nPlease enter a number");

                int val = 0;
                string check = Console.ReadLine();
                bool checkVal = int.TryParse(check, out val);

                if (check == "exit") break;
                if (!checkVal) continue;

                checkVal = checkDiv(check);

                Console.WriteLine("Is {0} divisible by 9 ?: {1}", check, checkVal);
            }
        }
    }
}