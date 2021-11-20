using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : CatObject
{
    // Start is called before the first frame update
    public int amountCap;
    public int amountIn;

    protected override void Setup(){
        this.gameObject.name = objectType;
        staffInteractable = true;
        amountIn = amountCap;
    }

    public override void DoAction(Staff staff){
        amountIn = amountCap;
    }

    //Gradually lowers the bowl's contents
    public virtual void Use(){
        amountIn--;
    }
    
    public override float EvalStaffNeed(){
        float eval = amountIn/(amountCap * 1.0f);
        return 1.0f - eval;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
