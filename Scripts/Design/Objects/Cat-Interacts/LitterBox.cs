using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitterBox : CatObject{
    // Start is called before the first frame update
    public int dirtiness;
    protected override void Start()
    {
        happinessIncrease = 5.0f;
        objectType = "LitterBox";
        Setup();
        staffInteractable = true;
    }

    public override void DoAction(Cat cat){
        if(cat.poop < 1.0f){
            cat.poop = 0.0f;
            dirtiness += 3;
        }
        cat.pee = 0.0f;
        dirtiness++;
    }

    public override void DoAction(Staff staff){
        dirtiness = 0;
    }

    public override float EvalStaffNeed(){
        float eval = dirtiness / 5.0f;
        return eval;
    }

    public override float EvalWillingness(Cat cat){
        float distWeight = Eval(cat);

        float poop = cat.poop;
        float pee = cat.pee;

        float dirty = Mathf.Exp(dirtiness/2.0f) - 1.0f;
        return (poop + pee) - dirty;
    }
}
