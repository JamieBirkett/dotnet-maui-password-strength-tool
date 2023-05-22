using System;
using System.Numerics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PasswordStrengthChecker.Models;
using PasswordStrengthChecker.Calulators;
using PasswordStrengthChecker.Validation;


namespace PasswordStrengthChecker.ViewModel;

public partial class MainViewModel : ObservableObject
{


    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(MainModel))]
    string password;
    partial void OnPasswordChanged(string value)
    {
        
        SetPasswordStrengthValues();
        CheckValidCharacters();
        SetBruteForceText();

    }

    void SetPasswordStrengthValues()
    {

        double entropy = PasswordEntropyCalculator.CalculateEntropy(Password);
        BigInteger bruteForceTime = BruteForceTimeCalculator.CalculateBruteForceTime(entropy);
        string bruteForceTimeFormatted = BruteForceTimeCalculator.FormatBruteForceTime(bruteForceTime);
        Color bruteForeTimeColour = PasswordValidator.getTimeColour(Password);

        MainModel.Entropy = entropy;
        MainModel.BruteForceTime = bruteForceTime;
        if (Password.Length >= 1)
        {
            MainModel.BruteForceTimeFormatted = bruteForceTimeFormatted;
            MainModel.BruteForeTimeColour = bruteForeTimeColour;
        }
        else
        {
            MainModel.BruteForceTimeFormatted = null;
            MainModel.BruteForeTimeColour =null;
        }
    }

    void SetBruteForceText()
    {
        if (Password.Length >= 1)
        {
            if (MainModel.BruteForceTimeFormatted == "Instantly")
            {
                MainModel.BruteForceHeader = "A computer would crack this";

                MainModel.BruteForceFooter = null;
            }
            else if (MainModel.BruteForceTimeFormatted != "Instantly")
            {
                MainModel.BruteForceHeader = "It would take a computer";
                MainModel.BruteForceFooter = "to crack this using brute force methods";
            }
            
        }
        else
        {
            MainModel.BruteForceHeader = "Try another password.\r\n";
            MainModel.BruteForceFooter = "Aim for a higher Entropy Score using the suggestions below";
        }
    }

    [ObservableProperty]
    public MainModel mainModel;


    public MainViewModel()
    {
        MainModel = new MainModel();
        InitializeDefaultValues();
    }

    public void CheckValidCharacters()
    {


        MainModel.UppercaseValid = PasswordValidator.ContainsCharacterType(Password, Validation.Requirements.Uppercase)
            ? MainModel.ValidCharacter_Present
            : MainModel.ValidCharacter_NotPresent;
        MainModel.LowercaseValid = PasswordValidator.ContainsCharacterType(Password, Validation.Requirements.Lowercase)
            ? MainModel.ValidCharacter_Present
            : MainModel.ValidCharacter_NotPresent;
        MainModel.NumberValid = PasswordValidator.ContainsCharacterType(Password, Validation.Requirements.Numbers)
            ? MainModel.ValidCharacter_Present
            : MainModel.ValidCharacter_NotPresent;
        MainModel.SpecialValid = PasswordValidator.ContainsCharacterType(Password, Validation.Requirements.Special)
            ? MainModel.ValidCharacter_Present
            : MainModel.ValidCharacter_NotPresent;
        MainModel.LengthValid = PasswordValidator.ContainsCharacterType(Password, Validation.Requirements.Length)
            ? MainModel.ValidCharacter_Present
            : MainModel.ValidCharacter_NotPresent;

    }

    private void InitializeDefaultValues()
    {
        MainModel.UppercaseValid = MainModel.ValidCharacter_NotPresent;
        MainModel.LowercaseValid = MainModel.ValidCharacter_NotPresent;
        MainModel.NumberValid = MainModel.ValidCharacter_NotPresent;
        MainModel.SpecialValid = MainModel.ValidCharacter_NotPresent;
        MainModel.LengthValid = MainModel.ValidCharacter_NotPresent;
        MainModel.BruteForceHeader = "Check how long it would take for a computer to crack your password\r\n";
        MainModel.BruteForceFooter = null;
    
    }

}


