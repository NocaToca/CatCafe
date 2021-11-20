using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A class that simply helps use debug
public static class CDebug{

    public static void PrintDate(Date date){
        string s = "Date: \n";
        s += "Current year: " + date.year + "\n";
        s += "Current month: " + date.month + "\n";
        s += "Current day: " + date.day + "\n";
        s += "Current hour: " + date.hour + "\n";
        s += "Current minute: " + date.minute + "\n";
        s += "Current second: " + date.seconds + "\n";
        Debug.Log(s);
    }

    public static void PrintCatStats(Cat cat){
        string s = cat.name + " stats: \n";
        s += "Friendliness: " + cat.friendliness + "\n";
        s += "Dominance: " + cat.dominance + "\n";
        s += "Playfullness: " + cat.playfullness + "\n";
        s += "Skittishness: " + cat.skittishness + "\n";
        s += "Socialibility: " + cat.socialibility + "\n";
        s += "Spontaneity: " + cat.spontaneity + "\n";
        Debug.Log(s);
    }

    public static void PrintCatInfo(Cat cat){
        string s = cat.name + " information: \n";
        s += "Happiness: " + cat.happiness + "\n";
        s += "Hunger: " + cat.hunger + "\n";
        s += "Thirst: " + cat.thirst + "\n";
        s += "Drowsiness: " + cat.drowsiness + "\n";
        s += "Pee: " + cat.pee + "\n";
        s += "Poo: " + cat.poop + "\n";
        Debug.Log(s);
    }
   
    public static void PrintAction(CatAction action){
       string s = "Cat action is currently set to " + action.name;
       Debug.Log(s);
    }
    public static void PrintAction(StaffAction action){
       string s = "Staff action is currently set to " + action.name;
       Debug.Log(s);
    }
}
