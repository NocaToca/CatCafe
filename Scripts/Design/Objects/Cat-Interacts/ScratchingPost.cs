using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchingPost : CatObject
{
    // Start is called before the first frame update
    protected override void Start()
    {
        happinessIncrease = 10.0f;
        objectType = "ScratchingPost";
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public override float EvalWillingness(Cat cat){
        float distWeight = Eval(cat);
        
        //Scratching post use playfullness plus how much the cat needs to scratch
        float playfullness = 1.0f - cat.playfullness;
        float itch = cat.scratchItch;
        return (playfullness * .5f + itch) * distWeight;
    }
}
