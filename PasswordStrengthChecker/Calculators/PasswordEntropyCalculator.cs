using System;
using PasswordStrengthChecker.Validation;
namespace PasswordStrengthChecker.Calulators
{
    public class PasswordEntropyCalculator
    {
        public static double CalculateEntropy(string password)
        {
            int characterSetSize = GetCharacterSetSize(password);
            int passwordLength = password.Length;
            double possibleCombinations = Math.Pow(characterSetSize, passwordLength);
            double entropy = Math.Log2(possibleCombinations);

            return Math.Round(entropy, 2);
        }

        private static int GetCharacterSetSize(string password)
        {
            int characterSetSize = 0;


            if (PasswordValidator.ContainsCharacterType(password, Requirements.Uppercase))
                characterSetSize += 26;

            if (PasswordValidator.ContainsCharacterType(password, Requirements.Lowercase))
                characterSetSize += 26;

            if (PasswordValidator.ContainsCharacterType(password, Requirements.Numbers))
                characterSetSize += 10;

            if (PasswordValidator.ContainsCharacterType(password, Requirements.Special))
                characterSetSize += 32;

            return characterSetSize;
        }

    }
}



