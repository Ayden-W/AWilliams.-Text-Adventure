﻿namespace Text_Adventure;
using Text_Adventure;
using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Diagnostics.Tracing;

internal class MainProgram
{

    public static string helpText = """
Each turn you can take one of 3 actions:

Travel - moves you randomly between 30-60 miles and takes 3-7 days(random).

Rest - increases health 1 level(up to 5 maximum) and takes 2-5 days(random).

Hunt - adds 100 lbs of food and takes 2-5 days(random).

When prompted for an action, you can also enter one of these
commands without using up your turn:

Status - lists food, health, distance traveled, and day.

Help - lists all the commands.

Quit - will end the game.

You can also use these shortcuts for commands:
| t | r | h | s | ? | q |
""";
    //state of the game
    public static int MilesTravled = 0;
    public static int foodRemaning = 500;
    public static int HealthLevel = 5;
    public static int Month = 3;
    public static int Day = 1;
    public static int SicknessesSufferedThisMonth = 0;
    public static string PlayerName = " ";

    //parameters that define the rules of the game cant change

    public static int MinMilesPerTravel = 30;
    public static int MaxMilesPerTravel = 60;
    public static int MinDaysPerTravel = 3;
    public static int MaxDaysPerTravel = 7;
    public static int MinDaysPerRest = 2;
    public static int MaxDaysPerRest = 5;
    public static int HealthChangePerRest = 1;
    public static int MaxHealth = 5;
    public static int FoodPerHunt = 100;
    public static int MinDaysPerHunt = 2;
    public static int MaxDaysPerHunt = 5;
    public static int FoodEatenPerDay = 5;
    public static string[] TypesOfSicknesses = { "Typhoid fever", "Cholera", "Dysentery", "Diphtheria", "Measles" };
    public static int MilesBetweenNYCAndOREGON = 2000;
    public static int[] MonthsWith31Days = { 1, 3, 5, 7, 8, 10, 12 };
    public static int[] MonthsWith30Days = { 4, 6, 9, 11 };
    public static int[] MonthsWith28Days = { 2 };
    public static string[] NameOfMonth = {"fake", "January", "February", "March", "April", "May", "June", "July",
"August", "September", "October", "November", "December"};

    string monthName = NameOfMonth[1];

    /*Converts are numeric date into a string.
    input: m - a month in the range 1-12
    input: d - a day in the range 1-31
    output: a string like "December 24".
    Note: this function does not enforce calendar rules. It's happy to output
    impossible strings like "June 95" or "February 31"*/
    Random random = new Random();


    public void DateReport()
    {
        string monthName = NameOfMonth[1];
        // month, day;
        Console.WriteLine(monthName + " " + Day + MilesTravled);
    }
    static void MilesRemaining()
    {
        Console.WriteLine(MilesBetweenNYCAndOREGON);
    }

    /*Returns the number of days in the month (28, 30, or 31).
    input: an integer from 1 to 12. 1=January, 2=February, etc.
    output: the number of days in the month. If the input is not in
    the required range, returns 0.*/
    public static int DaysInMonth(int m)
    {
        if (MonthsWith31Days.Contains(m))
        {
            return 31;
        }
        else if (MonthsWith30Days.Contains(m))
        {
            return 30;
        }
        else
        {
            return 30;
        }
    }


    /*Calculates whether a sickess occurs on the current day based
    on how many days remain in the month and how many sick days have
    already occured this month. If there are N days left in the month, then
    the chance of a sick day is either 0, 1 out of N, or 2 out of N, depending
    on whether there have been 2 sick days so far, 1 sick day so far, or no
    sick days so far.
    
    This system guarantees that there will be exactly
    2 sick days each month, and incidentally that every day of the month
    is equally likely to be a sick day (proof left to the reader!)*/

    static void RandomSicknessOccurs()
    {
        Random random = new Random();

        int activeSickness = random.Next(0, 4);

        //Generate random number between 1 and 32
        //if number is less than 4 you get sick
        int Chance = random.Next(1, 32) - 1;
        if (Chance <= 4)
        {
            string sickness = TypesOfSicknesses[activeSickness];
            Console.WriteLine("You Got Sick With" + sickness);
            SicknessesSufferedThisMonth++;
        }
    }

    static void consumeFood()
    {
        foodRemaning = foodRemaning - 5;
    }


    /*Repairs problematic values in the global (month, day) model where the day
    is is code 
    larger than the number of days in the month. If this happens, advances to
    the next also code
    month and knocks the day value down accordingly. Knows that different
    months have number of days code
    different numbers of days. Doesn't handle cases where the day is more than 28
    days in excess of the limit for that month -- could still end up with an
    impossible date after this function is called.
    
     Returns True if the global month/day values were altered, else False.*/

    public void MaybeRollBack()
    {
        if (DaysInMonth(Month) < Day)
        {
            Month = Month + 1;
            Day = 1;
        }
    }


    /*Causes a certain number of days to elapse. The days pass one at a time, and
    each day
    day brings with it a random chance of sickness. The sickness rules are
    quirky: player
    is guaranteed to fall ill a certain number of times each month, so illness
    needs to keep track of month changes.
    
    input: num_days - an integer number of days that elapse.*/

    public void AdvanceGameClock(int DaysPassed)
    {

    }



    public void Travel()
    {
        int RandomMilesTravled = random.Next(MinMilesPerTravel, MaxMilesPerTravel);
        Console.WriteLine(Day.ToString(), Month, MilesTravled);
        int DaysTravled = +random.Next(MinDaysPerTravel, MaxDaysPerTravel);
        AdvanceGameClock(DaysTravled);
        MilesTravled += RandomMilesTravled;
    }


    public void HandleRest()
    {
        Console.WriteLine("rest");
        int DaysRested = random.Next(MinDaysPerRest, MaxDaysPerRest);
        HealthLevel += 1;
        AdvanceGameClock(DaysRested);
        Console.WriteLine(Day.ToString(), Month, MilesTravled);
        if (HealthLevel > 5)
        {
            HealthLevel = 5;
        }
    }

    public void HandleHunt()
    {
        int CoinFlip = random.Next(0, 50);
        int DaysHunted = random.Next(MinDaysPerHunt, MaxDaysPerHunt);
        AdvanceGameClock(DaysHunted);
        if (CoinFlip <= 50)
        {
            HealthLevel += -1;
            Console.WriteLine("Your Hunt Came up Empty. Tonight you will be Cold and hungrey. -1HP" + HealthLevel);
        }
        else
        {
            foodRemaning += 50;
            Console.WriteLine("The Hunt was Very lucritive" + foodRemaning);
        }

    }

    public void HandleStatus()
    {
        Console.WriteLine(DateReport);
    }

    public void HandleHelp()
    {
        Console.WriteLine(helpText);
    }

    public void HandleQuit()
    {
        Playing = false;
    }

    public bool GameOver()
    {
        if (HealthLevel >= 0)
        {
            return true;
        }
        else if (foodRemaning == 0)
        {
            return true;
        }
        else if (playerWins())
        {
            return true;
        }
    }
    public bool playerWins()
    {
        if (MilesTravled >= 2000)
        {
            Console.WriteLine("Congrats You Made it You can now begin looking for gold and other tresures");
            return true;
        }
        else
        {
            return false;
        }
    }


    bool Playing = true;
    public static void Main(string[] args)
    {
        Console.WriteLine(" Welcome to the Oregon Trail!\nThe year is 1850 and Americans are headed out West to populate the frontier.\nYour goal is to travel by wagon train from Independence, MO to Oregon(2000 miles). You start on March 1st,\nand your goal is to reach Oregon by December 31st.\nThe trail is arduous.\nEach day costs you food and health.You can hunt and rest,\nbut you have to get there before winter!");
        Console.WriteLine(helpText);
        Console.WriteLine(value: RandomSicknessOccurs);
    }


}

