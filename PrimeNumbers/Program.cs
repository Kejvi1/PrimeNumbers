using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace PrimeNumbers
{
    class Program
    {
      
        public static void Main(string[] args)
        {
            //tuple declaration
            Tuple<List<int>,int> primes;

            //save in a tuple variable the list of prime numbers and the largest prime number
            primes = ListOfPrimesUnder1Milli();

            //save in sum variable the sum of all the items
            int sum = SumNumbersArray(primes);

            //output the result
            Console.WriteLine("{0} is the prime number of the sum of all the prime numbers under 1 million!",sum);
            Console.ReadKey();
        }

        //create list of all prime numbers under 1 million
        public static Tuple<List<int>, int> ListOfPrimesUnder1Milli()
        {
            List<int> primes = new List<int>();
            for (int i = 1; i <= 1000000; i++)
            {
                bool isprime = CheckIfPrime(i);
                if (isprime == true)
                {
                    primes.Add(i);
                }

            }
            int lastPrime = primes.Last();
            Tuple<List<int>, int> primenumbers = new Tuple<List<int>, int>(primes, lastPrime);
            return primenumbers;
        }

        //check if the number parsed is prime or not
        public static bool CheckIfPrime(int number)
        {
            //if number is 1 it is not prime
            if (number == 1) return false;
            //if number is 2 it is prime
            if (number == 2) return true;

            //if number is even greater than 2 it is not prime
            if (number % 2 == 0) return false;

            //iterate for all numbers greater than 3 up to the square root of the number that we have
            int nr = Convert.ToInt32(Math.Floor(Math.Sqrt(number)));
            for (int i = 3; i <= nr; i++)
            { 
                //if the remainder is 0 -> number is not prime
                if (number % i == 0) return false;
            }

            return true;
        }
    

        

        //add up all the numbers in tuple and check if it is prime
        public static int SumNumbersArray(Tuple<List<int>, int> primenumbers)
        {
            int sum = 0;
            int temp = 0;
            //iterate list item of tuple
            foreach(int number in primenumbers.Item1)
            {
                //if the sum of all the items is lower or equal than the largest prime number under 1 million, continue adding up
                if(sum <= primenumbers.Item2)
                {
                    sum += number;

                    //check if sum of numbers is prime
                    bool isPrime = CheckIfPrime(sum);
                    if (isPrime)
                    {
                        temp = sum;
                        
                    }

                }
                else
                {
                    break;
                }

            }
            return temp;
        }

    }
}
