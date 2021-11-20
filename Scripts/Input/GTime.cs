using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GTime : MonoBehaviour
{   
    public static Date currentTime;
    public static float deltaTimeSeconds;
    public static int deltaTimeMinutes;

    public Date MainOffset;

    [Header("Time Settings")]
    [Tooltip("The rate at which time progresses the game.")]
    public float timeRate = 10.0f;

    [Tooltip("The rate at which time progresses the date.")]
    //How much game time diverges from real time
    public float timeWeight = 10.0f;

    private float timeChange;

    int year{get {return currentTime.year;}}
    int month{get {return currentTime.month;}}
    int day{get {return currentTime.day;}}
    int hour{get {return currentTime.hour;}}
    int minute{get {return currentTime.minute;}}
    // Start is called before the first frame update
    void Start()
    {
        MainOffset = new Date(2021, 11, 3, 9, 18);
        currentTime = MainOffset;
        //DebugPrintDate();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D)){
            CDebug.PrintDate(currentTime);
        }
        
        if(timeChange > 60.0f){
            currentTime = new Date(currentTime, timeChange * timeWeight);
            timeChange = 0.0f;
            //DebugPrintDate();
        }

        deltaTimeSeconds = Time.deltaTime * timeRate;
        deltaTimeMinutes = (int)(deltaTimeSeconds % 60.0f) - deltaTimeMinutes;
        timeChange += deltaTimeSeconds;
    }

    
}
