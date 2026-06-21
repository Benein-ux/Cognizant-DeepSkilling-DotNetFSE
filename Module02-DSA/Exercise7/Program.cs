using System;
using System.Collections.Generic;

namespace DSA.Recursion
{
    class Program
    {
        // Dictionary to store cached results (Memoization) to prevent redundant calculations
        private static Dictionary<int, double> _memoCache = new Dictionary<int, double>();

        static void Main(string[] args)
        {
            double presentValue = 1000.0; // Initial investment
            double growthRate = 0.05;     // 5% growth rate
            int years = 10;               // Predict 10 years into the future

            Console.WriteLine("--- Financial Forecasting (Recursive) ---");
            
            double futureValue = CalculateFutureValue(presentValue, growthRate, years);
            Console.WriteLine($"Forecasted Value after {years} years: ${Math.Round(futureValue, 2)}");

            /*
             * ANALYSIS:
             * Time Complexity: O(n) where n is the number of years, because the function 
             * makes exactly 'n' recursive calls. 
             * Optimization: We implemented a Dictionary cache (Memoization) above. If we 
             * need to query year 8 after querying year 10, the algorithm pulls it instantly 
             * from memory (O(1)) instead of recalculating the entire recursive tree.
             */
        }

        public static double CalculateFutureValue(double pv, double rate, int year)
        {
            // Base Case: Year 0 means the value is just the present value
            if (year == 0)
                return pv;

            // Optimization Check: If we already calculated this year, return the cached value
            if (_memoCache.ContainsKey(year))
                return _memoCache[year];

            // Recursive Case: Calculate the previous year's value, then apply this year's growth
            double result = CalculateFutureValue(pv, rate, year - 1) * (1 + rate);

            // Store in cache before returning
            _memoCache[year] = result;

            return result;
        }
    }
}