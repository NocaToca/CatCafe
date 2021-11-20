using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBowl : Bowl
{
    // Start is called before the first frame update
    protected override void Start()
    {
        happinessIncrease = 10.0f;
        objectType = "FoodBowl";
        amountCap = 5;
        Setup();

        
    }

    public override void DoAction(Cat cat){
        //Debug.Log("Om om om");
        cat.hunger = 0.0f;
        Use();
    }

    public override float EvalWillingness(Cat cat){
        float distWeight = Eval(cat);

        float hunger = cat.hunger;
        if(amountIn == 0){
            return -100.0f;
        }
        return hunger;
    }
}
