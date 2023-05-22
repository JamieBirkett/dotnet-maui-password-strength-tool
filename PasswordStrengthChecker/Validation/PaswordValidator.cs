using System;
namespace PasswordStrengthChecker.Validation

//This class could do with being refactored
{
    public enum Requirements
    {
        Uppercase,
        Lowercase,
        Numbers,
        Special,
        Length
    }

    public static class PasswordValidator
    {
        public static bool ContainsCharacterType(string password, Requirements character)
        {
            switch (character)
            {
                case Requirements.Uppercase:
                    return System.Text.RegularExpressions.Regex.IsMatch(password, "[A-Z]");

                case Requirements.Lowercase:
                    return System.Text.RegularExpressions.Regex.IsMatch(password, "[a-z]");

                case Requirements.Numbers:
                    return System.Text.RegularExpressions.Regex.IsMatch(password, "[0-9]");

                case Requirements.Special:
                    return System.Text.RegularExpressions.Regex.IsMatch(password, "[^A-Za-z0-9]");

                case Requirements.Length:
                    return (password.Length >= 12);

                default:
                    return false;
            }
        }



        public static bool IsPasswordValidated(string password)
        {
            bool passwordValidated = false;

            if (ContainsCharacterType(password, Requirements.Uppercase))
                passwordValidated = true;

            if (ContainsCharacterType(password, Requirements.Lowercase))
                passwordValidated = true;

            if (ContainsCharacterType(password, Requirements.Numbers))
                passwordValidated = true;

            if (ContainsCharacterType(password, Requirements.Special))
                passwordValidated = true;

            return passwordValidated;
        }

        /*Fix this*/
        public static int TotalCharacterTypes(string password)
        {
            int i = 0;

            if (ContainsCharacterType(password, Requirements.Uppercase))
                i += 1;

            if (ContainsCharacterType(password, Requirements.Lowercase))
                i += 1;

            if (ContainsCharacterType(password, Requirements.Numbers))
                i += 1;

            if (ContainsCharacterType(password, Requirements.Special))
                i += 1;

            if (ContainsCharacterType(password, Requirements.Length))
                i += 1;

            return i;
        }


        public static Color getTimeColour(string password)
        {
            int colourIdentifier = TotalCharacterTypes(password);

            switch (colourIdentifier)
            {
                case 1:
                    return Colors.Red;
                case 2:
                    return Colors.OrangeRed;
                case 3:
                    return Colors.Orange;
                case 4:
                    return Colors.Gold;
                case 5:
                    return Colors.LimeGreen;
                default:
                    return Colors.Black;
            }
        }
    }
}


