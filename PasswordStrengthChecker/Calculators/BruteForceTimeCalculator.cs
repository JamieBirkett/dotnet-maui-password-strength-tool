using System;
using System.Numerics;


namespace PasswordStrengthChecker.Calulators
{

    public static class BruteForceTimeCalculator
    {
        public static BigInteger CalculateBruteForceTime(double entropy)
        {
            BigInteger attemptsPerSecond = new BigInteger(1e9); // Assumed number of attempts per second by using Brute Force methods
            BigInteger totalAttempts = BigInteger.Pow(2, (int)entropy);
            BigInteger seconds = totalAttempts / attemptsPerSecond;

            return seconds;
        }

        public static string FormatBruteForceTime(BigInteger bruteForceTime)
        {
            BigInteger microseconds = 1;
            BigInteger milliseconds = microseconds * 1000;
            BigInteger seconds = milliseconds * 1000;
            BigInteger minutes = seconds * 60;
            BigInteger hours = minutes * 60;
            BigInteger days = hours * 24;
            BigInteger months = days * 30;
            BigInteger years = days * 365;
            BigInteger millionYears = years * 1000000;
            BigInteger billionYears = millionYears * 1000;
            BigInteger trillionYears = billionYears * 1000;
            BigInteger quadrillionYears = trillionYears * 1000;
            BigInteger quintillionYears = quadrillionYears * 1000;
            BigInteger sextillionYears = quintillionYears * 1000;
            BigInteger septillionYears = sextillionYears * 1000;

            if (bruteForceTime == null) // Entry null than 1 microsecond
            {
                return null;
            }
            else if (bruteForceTime < microseconds) // Less than 1 microsecond
            {
                return "Instantly";
            }
            else if (bruteForceTime < milliseconds) // Less than 1 millisecond
            {
                return $"{bruteForceTime / microseconds} microseconds";
            }
            else if (bruteForceTime < seconds) // Less than 1 second
            {
                return $"{bruteForceTime / milliseconds} milliseconds";
            }
            else if (bruteForceTime < minutes) // Less than 1 minute
            {
                return $"{bruteForceTime / seconds} seconds";
            }
            else if (bruteForceTime < hours) // Less than 1 hour
            {
                return $"{bruteForceTime / minutes} minutes";
            }
            else if (bruteForceTime < days) // Less than 1 day
            {
                return $"{bruteForceTime / hours} hours";
            }
            else if (bruteForceTime < months) // Less than 1 month (30 days)
            {
                return $"{bruteForceTime / days} days";
            }
            else if (bruteForceTime < years) // Less than 1 year
            {
                return $"{bruteForceTime / months} months";
            }
            else if (bruteForceTime < millionYears) // Less than 1 million years
            {
                return $"{bruteForceTime / years} years";
            }
            else if (bruteForceTime < billionYears) // Less than 1 billion years
            {
                return $"{bruteForceTime / millionYears} million years";
            }
            else if (bruteForceTime < trillionYears) // Less than 1 trillion years
            {
                return $"{bruteForceTime / billionYears} billion years";
            }
            else if (bruteForceTime < quadrillionYears) // Less than 1 quadrillion years
            {
                return $"{bruteForceTime / trillionYears} trillion years";
            }
            else if (bruteForceTime < quintillionYears) // Less than 1 quintillion years
            {
                return $"{bruteForceTime / quadrillionYears} quadrillion years";
            }
            else if (bruteForceTime < sextillionYears) // Less than 1 sextillion years
            {
                return $"{bruteForceTime / quintillionYears} quintillion years";
            }
            else if (bruteForceTime < septillionYears) // Less than 1 septillion years
            {
                return $"{bruteForceTime / sextillionYears} sextillion years";
            }
            else // Greater than or equal to septillion years
            {
                return "Until the end of time";
            }
        }
    }
}

