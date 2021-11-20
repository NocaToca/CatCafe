using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatObject : MonoBehaviour
{
    public bool staffInteractable;
    public float happinessIncrease;
    protected string objectType;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void DoAction(Cat cat){
        //lol this doesnt do anything
    }

    public virtual void DoAction(Staff staff){
        //lol this one also doesnt do anything
    }

    protected virtual void Setup(){
        this.gameObject.name = objectType;
        staffInteractable = false;
    }

    public virtual float Eval(Cat cat){
        float dist = Vector3.Distance(cat.transform.position, this.transform.position);

        dist = 1 - (dist/cat.detectionDistance);
        return dist;
    }

    //Needs to be implemented by child classes
    public virtual float EvalWillingness(Cat cat){
        return 0.0f;
    }

    public virtual float EvalStaffNeed(){
        Debug.LogError("Object not set up to handle staff interaction. Somehow detected that it could be");
        return -100.0f;
    }

    public static CatObject GetCatObject(GameObject obj){
        //Evaluates the cat's willingness to go to a certain object
        BallChaser bc = obj.GetComponent<BallChaser>();
        if(bc){
            return bc;
        }
        
        CatBed cb = obj.GetComponent<CatBed>();
        if(cb){
            return cb;
        }

        ScratchingPost sp = obj.GetComponent<ScratchingPost>();
        if(sp){
            return sp;
        }

        FoodBowl fb = obj.GetComponent<FoodBowl>();
        if(fb){
            return fb;
        }

        WaterBowl wb = obj.GetComponent<WaterBowl>();
        if(wb){
            return wb;
        }

        LitterBox lb = obj.GetComponent<LitterBox>();
        if(lb){
            return lb;
        }

        Debug.LogError("You tried to access a cat object that doesnt exist.");
        return null;
    }

    public static bool HasCatObject(GameObject obj){
        BallChaser bc = obj.GetComponent<BallChaser>();
        if(bc){
            return true;
        }
        
        CatBed cb = obj.GetComponent<CatBed>();
        if(cb){
            return true;
        }

        ScratchingPost sp = obj.GetComponent<ScratchingPost>();
        if(sp){
            return true;
        }

        FoodBowl fb = obj.GetComponent<FoodBowl>();
        if(fb){
            return true;
        }

        WaterBowl wb = obj.GetComponent<WaterBowl>();
        if(wb){
            return true; 
        }

        LitterBox lb = obj.GetComponent<LitterBox>();
        if(lb){
            return true;
        }

        return false;
    }

    public static bool StaffInteractable(GameObject obj){
        BallChaser bc = obj.GetComponent<BallChaser>();
        if(bc){
            return bc.staffInteractable;
        }
        
        CatBed cb = obj.GetComponent<CatBed>();
        if(cb){
            return cb.staffInteractable;
        }

        ScratchingPost sp = obj.GetComponent<ScratchingPost>();
        if(sp){
            return sp.staffInteractable;
        }

        FoodBowl fb = obj.GetComponent<FoodBowl>();
        if(fb){
            return fb.staffInteractable;
        }

        WaterBowl wb = obj.GetComponent<WaterBowl>();
        if(wb){
            return wb.staffInteractable; 
        }

        LitterBox lb = obj.GetComponent<LitterBox>();
        if(lb){
            return lb.staffInteractable;
        }

        return false;
    }
}
