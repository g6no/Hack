using System.Collections;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HackThePlanet : MonoBehaviour
{
    // Start is called before the first frame update
    string password;
    string[] level1Passwords = { "coded", "laptop", "mouse", "challenge", "hack" };
    string[] level2Passwords = { "airport", "security", "airplane", "baggage" };
    int level;
    int counter = 0;
    enum Screen {MainMenu, Password, Win};
    Screen currentScreen = Screen.MainMenu;
    void Start()
    {
        ShowMainMenu("Coded Students");
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("You have chosen level " + level);
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:


                //Random r = new Random();
                //foreach (int i in Enumerable.Range(0, level1Passwords.Length - 1).OrderBy(x => ran.Next()))
                //{
                //    password = level1Passwords[i];
                //}
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                Terminal.WriteLine(password.Anagram());

                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                Terminal.WriteLine(password.Anagram());

                break;
            default:
                Terminal.WriteLine("Invalid level selected");
                break;
        }
    }
    void ShowMainMenu(string input)
    {
        Terminal.ClearScreen();
        currentScreen = Screen.MainMenu;
        Terminal.WriteLine($"Welcome {input}");
        Terminal.WriteLine("Choose your hacking target");
        Terminal.WriteLine("Type 1 for CODED");
        Terminal.WriteLine("Type 2 for airport");
    }
    void SetLevel(string currentLevel)
    {
        if (currentLevel == "1")
        {
            level = 1;
            Terminal.ClearScreen();
            currentScreen = Screen.Password;
            Terminal.WriteLine("You have chosen level " + level + "!");
            SetRandomPassword();
        }
        else if(currentLevel == "2")
        {
            level = 2;
            Terminal.ClearScreen();
            currentScreen = Screen.Password;
            Terminal.WriteLine("You have chosen level " + level + "!");
            SetRandomPassword();
        }

    }
    void OnUserInput(string input)
    {
        if (input ==  "menu")
        {
            ShowMainMenu("back");
        }
        else if(currentScreen == Screen.MainMenu)
        {
            SetLevel(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
        else if (currentScreen == Screen.Win)
        {
            if (input == "menu")
            {
                ShowMainMenu("back, and congratulations!");
            }
            else
            {
                SetLevel(input);
            }
        }
    }
    // Update is called once per frame

        void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            //counter = 0;
            counter += 1;
            //Terminal.WriteLine("" + counter);
            if (counter < 4)
            {
                Terminal.WriteLine("YIKES, You should try again ");
            }
            else if (counter > 3 && counter < 6)
            {
                Terminal.WriteLine("WOW, more than three tries?");
            }
            else if (counter >= 6)
                {
                Terminal.WriteLine("you should find another thing to do......");
            }
        }
    }
    void DisplayWinScreen()
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Win;
        ShowLevelRewards();
        Terminal.WriteLine("Type menu to go back.");
        Terminal.WriteLine("Type 1 for level 1");
        Terminal.WriteLine("Type 2 for level 2");


    }
    void ShowLevelRewards()
    {
        Terminal.WriteLine("Congratulations on completing level " + level);
        Terminal.WriteLine(@"__          _______ _   _ _ 
\ \        / |_   _| \ | | |
 \ \  /\  / /  | | |  \| | |
  \ \/  \/ /   | | | . ` | |
   \  /\  /   _| |_| |\  |_|
    \/  \/   |_____|_| \_(_)
                            ");
    }
        void Update()
    {

    }
}
