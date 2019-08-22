using System;
using System.Collections.Generic;

namespace RandomQ {
    class MyApp {
        Random r = new Random();
        
        public KeyValuePair<string, string> RandomQuestion (Dictionary<string, string> refDict,
                                                            out int questionNum) {
            int currentQ, countQ;

            currentQ = r.Next(1, refDict.Count + 1);
            countQ = 0;
            questionNum = 0;

            foreach (KeyValuePair<string, string> kvp in refDict) {
                countQ++;
                if (countQ == currentQ) {
                    questionNum = currentQ;
                    return kvp;
                }
            }

            return new KeyValuePair<string, string> ("", "");
        }

        static void Main(string[] args) {
            MyApp app = new MyApp();
            Dictionary<string, string> myList = new Dictionary<string, string>();
            KeyValuePair<string, string> myQuestion = new KeyValuePair<string, string>();
            bool loop = true;

            myList.Add("What color is the sky?", "blue");
            myList.Add("What color is grass?", "green");
            myList.Add("What color is fire?", "red");
            myList.Add("What color is the sun?", "yellow");

            while (loop) {
                int currentQ = 0;
                myQuestion = app.RandomQuestion(myList, out currentQ);
                Console.WriteLine("\nQuestion #{0}: {1}", currentQ, myQuestion.Key);

                int attempts = 0;

                while (true) {
                    attempts++;
                    string answer = Console.ReadLine();
                    answer = answer.ToLower();

                    if (answer == myQuestion.Value) {
                        Console.WriteLine("\nCorrect Answer!");
                        break;
                    }
                    else {
                        Console.WriteLine("\nIncorrect Answer!");
                        continue;
                    }
                }

                Console.WriteLine("It only took you {0} attempts!", attempts);

                Console.WriteLine("\nWould you like to try again?");
                while (true) {
                    string repeat = Console.ReadLine();

                    if (repeat == "y" || repeat == "yes") {
                        break;
                    }
                    else 
                    if (repeat == "n" || repeat == "no") {
                        loop = false;
                        break;
                    }
                    else {
                        Console.WriteLine("\nPlease enter either yes or no");
                        continue;
                    }
                }
            }
        }
    }
}