using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Just a script to hold all of our global structs
public struct Walk{
    public float angle;
    public Vector3 position;

    public Walk(Vector3 pos){
        position = pos;
        angle = 0.0f;
    }
}

public struct CatAction{
    public readonly CatObject gameObject;
    public readonly string name;
    
    public CatAction(CatObject go, string name){
        gameObject = go;
        this.name = name;
    }
}

public struct StaffAction{
    public readonly CatObject gameObject;
    public readonly string name;
    
    public StaffAction(CatObject go, string name){
        gameObject = go;
        this.name = name;
    }
}


public struct Date{
    public readonly int year;
    public readonly int month;
    public readonly int day;
    public readonly int hour;
    public readonly int minute;

    public float seconds;

    public Date(int y, int m, int d, int h, int mi){
        year = y;
        month = m;
        day = d;
        hour = h;
        minute = mi;

        seconds = 0.0f;
    }

    public Date(Date offset, float seconds){
        minute = (offset.minute) + (int)(seconds / 60.0f);
        hour = offset.hour + (minute/60);
        day = offset.day + (hour/24);
        month = offset.month + (day/31);
        year = offset.year + (month/13);

        minute %= 60;
        hour %= 24;
        day %= 31;
        month %= 13;
        day = (day == 0) ? day + 1 : day;
        month = (month == 0) ? month + 1 : month;

        this.seconds = seconds;
    }

    public Date(float seconds, Date offset){
        year = (int)(seconds / 31536000.0f);
        month = (int)((seconds - (31536000 * year)) / 2628288.0f);
        day = (int)((seconds - (31536000 * year) - (2628288.0f * month)) / 86400.0f);
        hour = (int)((seconds - (31536000 * year) - (2628288.0f * month) - (86400.0f * day)) / 3600.0f);
        minute = (int)((seconds - (31536000 * year) - (2628288.0f * month) - (86400.0f * day) - (3600.0f * hour)) / 60.0f);

        year += offset.year;
        month += offset.month;
        day += offset.day;
        hour += offset.hour;
        minute += offset.minute;

        this.seconds = (seconds - (31536000 * year) - (2628288.0f * month) - (86400.0f * day) - (3600.0f * hour) - (60.0f * minute));
    }
}
