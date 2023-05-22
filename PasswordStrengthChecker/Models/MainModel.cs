using System;
using System.Numerics;


namespace PasswordStrengthChecker.Models
{
    public class MainModel
    {
        public const string ValidCharacter_Present = "tick_green.png";
        public const string ValidCharacter_NotPresent = "tick_grey.png";

        public double Entropy { get; set; }
        public BigInteger BruteForceTime { get; set; }
        public String BruteForceTimeFormatted { get; set; }
        public String BruteForceHeader { get; set; }
        public String BruteForceFooter { get; set; }
        public Color BruteForeTimeColour { get; set; }
        public String UppercaseValid { get; set; }
        public String LowercaseValid { get; set; }
        public String NumberValid { get; set; }
        public String SpecialValid { get; set; }
        public String LengthValid { get; set; }
        
    }
}
