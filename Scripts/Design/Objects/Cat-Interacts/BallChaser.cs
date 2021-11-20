using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallChaser : CatObject
{
    // Start is called before the first frame update
    protected override void Start()
    {
        happinessIncrease = 10.0f;
        objectType = "BallChaser";
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void DoAction(Cat cat){
        //Chasing the ball makes the kitty tired!
        cat.drowsiness += .5f;
    }

    public override float EvalWillingness(Cat cat){
        float distWeight = Eval(cat);

        //Ball chaser use playfullness
        float playfullness = 1.0f + cat.playfullness;
        return playfullness * distWeight;
    }
}
