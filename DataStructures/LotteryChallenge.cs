using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class LotteryChallenge
    {
        //ExigerChallenge.cs

// Given a list of unique lottery numbers and a number
// Find all winning triplets from the list of lottery numbers such that the numbers in a triplet sum up to the given number
// Your winning sets should not contain duplicates
// [1, 2, 3]...winning number = 6, [1, 2, 3]
// [1, 2, 3], [2, 3, 1] is invalid

        public static void Solve(string[] args)
        {
            // ex2
            // 12, 3, 1, 2, -6, 5, -8, 6
            // winningNumber = 0
            // [-8, 2, 6], [-8, 3, 5], [-6, 1, 5]
            // Notice there is not a solution here like [2, -8, 6]

            int[] lotteryNumbers = new int[] { 12, 3, 1, 2, -6, 5, 0, -8, -1, 6, -5 };
            int winningNumber = 0;
            WinningLotteryNumbers(lotteryNumbers, winningNumber);


        }
        public static void WinningLotteryNumbers(int[] lotteryNumbers, int winningNumber)
        {
            //sort array from least to greatest
            //starting with the first index in the array, loop through and add the next index
            //if those 2 numbers >= 6  break out of the loop
            //if 2 numbers < 6 try adding the next index
            //if those 3 numbers = 6, save that combo
            //if those 3 number > 6, break out of that loop continue //the next index in the outer loop
            // Array.Sort();
            Array.Sort(lotteryNumbers);
            //create a hashtable of all the potential combinatiosn
            //actualCombo to it's sum
            //key would actualCombo, value would be the sum of the values
            // Dictionary<> possibleCombos = new Dictionary<int, int[3]>();
            // foreach (var item in lotteryNumbers)
            // {
            //   possibleCombos.Add()
            // }

            // are your loop ranges correct
            // ending range here
            for (int i = 0; i < lotteryNumbers.Length; i++)
            {
                if (lotteryNumbers[i] > winningNumber)
                    continue;
                int[] goodCombo = new int[3]; //potential combinations
                goodCombo[0] = lotteryNumbers[i];
                // and then the ending range here
                // -1 was good here
                for (int j = i + 1; j < lotteryNumbers.Length - 1; j++)
                {
                    //if our first number is greater than the winning number, no point in checking since the other numbers will be higher
                    if (lotteryNumbers[i] + lotteryNumbers[j] > winningNumber)
                        continue;

                    goodCombo[1] = lotteryNumbers[j];
                    // k was fine
                    for (int k = j + 1; k < lotteryNumbers.Length; k++)
                    {
                        if (lotteryNumbers[i] + lotteryNumbers[j] + lotteryNumbers[k] > winningNumber)
                            continue;

                        goodCombo[2] = lotteryNumbers[k];
                        if (goodCombo[0] + goodCombo[1] + goodCombo[2] == winningNumber)
                        {
                            Console.WriteLine("{0}, {1}, {2}", goodCombo[0], goodCombo[1], goodCombo[2]);
                        }
                    }
                }
            }

        }
    }
}

