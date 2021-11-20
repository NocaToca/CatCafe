using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//For use with the cat class
public static class CAlgorithms{

    public static float CalculateWeightedHappiness(float happiness, float hunger, float thirst, float sleepiness, float pee, float poop){
        //Function is based on logramithric growth
        float eval = Mathf.Sqrt(hunger)/10.0f + Mathf.Sqrt(thirst)/5.0f + Mathf.Sqrt(sleepiness)/25.0f;
        if(hunger > 50.0f){
            eval *= 5.0f;
        }
        if(thirst > 50.0f){
            eval *= 5.0f;
        }
        
        return eval;
    }

    public static CatAction FindObjectToInteractWith(Cat cat, List<GameObject> objects){

        if(objects.Count == 0){
            return new CatAction(null, "none");
        }

        List<GameObject> interactables = new List<GameObject>();

        foreach(GameObject go in objects){
            if(CatObject.HasCatObject(go)){
                interactables.Add(go);
            }
        }

        float maxIncrease = 0.0f;
        GameObject interact = interactables[0];
        foreach(GameObject go in interactables){
            float eval;
            eval = EvalOverallWillingness(cat, go);
            if(eval > maxIncrease){
                interact = go;
                maxIncrease = eval;
            }
        }

        return new CatAction(CatObject.GetCatObject(interact), interact.name);

    }

    public static StaffAction FindObjectToInteractWith(Staff staff, List<GameObject> objects){

        if(objects.Count == 0){
            return new StaffAction(null, "none");
        }

        List<GameObject> interactables = new List<GameObject>();

        foreach(GameObject go in objects){
            if(CatObject.HasCatObject(go)){
                if(CatObject.StaffInteractable(go)){
                    interactables.Add(go);
                }
            }
        }

        float maxIncrease = 0.0f;
        GameObject interact = interactables[0];
        foreach(GameObject go in interactables){
            float eval;
            eval = EvalStaffNeed(go);
            if(eval > maxIncrease){
                interact = go;
                maxIncrease = eval;
            }
        }

        return new StaffAction(CatObject.GetCatObject(interact), interact.name);

    }

    public static float EvalOverallWillingness(Cat cat, GameObject obj){

        return CatObject.GetCatObject(obj).EvalWillingness(cat);
    }

    public static float EvalStaffNeed(GameObject go){
        return CatObject.GetCatObject(go).EvalStaffNeed();
    }

    public static float CalculateHappinessIncrease(Cat cat, CatAction action){
        float f = 0.0f;
        f += action.gameObject.happinessIncrease;

        return f;
    }

    public static float Clamp0Val(float value, float clamp){
        return (value > clamp) ? clamp : (value < 0.0f) ? 0.0f : value;
    }

    public static float ClampAngle(float angle){
        if(angle < 0.0f){
            angle += 2 * Mathf.PI;
        }
        return (angle > 2 * Mathf.PI) ? ClampAngle(angle - (2 * Mathf.PI)) : angle;
    }

    public static float FindAngleToVector(Vector3 input, Vector3 destination){
        float ang = Vector3.SignedAngle(input, destination, Vector3.up);  
        ang += 180.0f;
        return ang * Mathf.Deg2Rad;
    }
}
