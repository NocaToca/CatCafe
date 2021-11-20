using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cat))]
[RequireComponent(typeof(Rigidbody2D))]
public class CatController : MonoBehaviour
{
    Rigidbody rb;
    float angthesh = .2f;

    Walk walk;
    Cat cat;

    Transform destinationPosition;
    private float timeSinceLastAction;
    // Start is called before the first frame update
    void Start(){
        cat = GetComponent<Cat>();
        rb = GetComponent<Rigidbody>();
        walk = new Walk(this.transform.position);
    }

    // Update is called once per frame
    void Update(){
        DecideAction();
        //Debug.Log(timeSinceLastAction);
        if(Input.GetKeyDown(KeyCode.I)){
            CDebug.PrintCatInfo(cat);
        }
        if(Input.GetKeyDown(KeyCode.S)){
            CDebug.PrintCatStats(cat);
        }
        UpdatePosition();
    }

    void DecideAction(){
        if(timeSinceLastAction > cat.actionInterval && !cat.HasAction()){
            timeSinceLastAction = 0.0f;
            CatAction action = Cat.ChooseSomething(cat);
            cat.SetAction(action);
            cat.UpdateHappiness(action);
            cat.isAction = true;
            CDebug.PrintAction(cat.action);
        } else 
        if(!cat.HasAction()){
            timeSinceLastAction += GTime.deltaTimeSeconds;
        }
    }

    void ChooseNewDestination(){
        if(cat.HasAction()){
            destinationPosition = cat.action.gameObject.transform;
        }
    }

    void UpdatePosition(){
        if(!cat.HasAction()){
            //IdleWalk();
            return;
        }

        if(destinationPosition == null){
            
            ChooseNewDestination();
            return;
        } else {
            if(Vector3.Distance(transform.position, destinationPosition.position) < 2.0f){
                cat.CompleteAction();
                destinationPosition = null;
                return;
            } else {
                // transform.position = destinationPosition.position;
                // walk.position = transform.position;
                Bounce();
            }
        }
    }

    void Bounce(){
        //Boing!
        if(Mathf.Abs(rb.velocity.y) > .01f){
            return;
        }
        Vector3 vel = new Vector3(0,0,0);

        vel.y = 5.0f;
        float angle = CAlgorithms.FindAngleToVector(transform.position, destinationPosition.position); 

        //rb.velocity = new Vector3(Mathf.Cos(angle), vel.y, Mathf.Sin(angle));
    }

    
}
