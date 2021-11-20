using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBowl : Bowl
{
    protected override void Start()
    {
        happinessIncrease = 10.0f;
        objectType = "WaterBowl";
        amountCap = 10;
        Setup();
    }

    public override void DoAction(Cat cat){
        //Debug.Log("Om om om");
        cat.thirst = 0.0f;
        Use();
    }

    public override float EvalWillingness(Cat cat){
        float distWeight = Eval(cat);

        float thirst = cat.thirst;
        if(amountIn == 0){
            return -100.0f;
        }
        return thirst;
    }
}
