using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//In terms of information, the UI will draw most of it from this class
public static class GameMode{
    public static Date date{get{return GTime.currentTime;}}

    public static float balance;

}
