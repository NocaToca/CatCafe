using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBed : CatObject
{
    // Start is called before the first frame update
    protected override void Start()
    {
        happinessIncrease = 10.0f;
        objectType = "CatBed";
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void DoAction(Cat cat){
        cat.drowsiness = 0.0f;
    }

    public override float EvalWillingness(Cat cat){
        float distWeight = Eval(cat);
        
        //Cat beds use negated playfullness
        float playfullness = 1.0f - cat.playfullness;
        
        //Lets see if our cat is tired too:
        playfullness += cat.drowsiness/10.0f; //We dont want it to overpower the other stats too much, thing playful cats may be only sleeping!

        return playfullness * distWeight;
    }
}
