using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Staff))]
[RequireComponent(typeof(Rigidbody2D))]
public class StaffController : MonoBehaviour
{
    Staff staff;
    Rigidbody rb;

    float timeSinceLastAction;
    Transform destinationPosition;

    // Start is called before the first frame update
    void Start()
    {
        staff = GetComponent<Staff>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        DecideAction();
        UpdatePosition();
    }

    void ChooseNewDestination(){
        if(staff.HasAction()){
            destinationPosition = staff.action.gameObject.transform;
        }
    }

    void UpdatePosition(){
        if(!staff.HasAction()){
            //IdleWalk();
            return;
        }

        if(destinationPosition == null){
            ChooseNewDestination();
            return;
        } else {
            if(Vector3.Distance(transform.position, destinationPosition.position) < 2.0f){
                staff.CompleteAction();
                destinationPosition = null;
                return;
            } else {
                // transform.position = destinationPosition.position;
                // walk.position = transform.position;
                Roll();
            }
        }
    }

    void Roll(){
        if(Mathf.Abs(rb.velocity.y) > .01f){
            return;
        }
        float angle = CAlgorithms.FindAngleToVector(transform.position, destinationPosition.position); 

        //rb.velocity = new Vector3(Mathf.Cos(angle) * 2.0f, 0, Mathf.Sin(angle) * 2.0f);
    }

    private void DecideAction(){
        if(timeSinceLastAction > staff.actionInterval && !staff.HasAction()){
            timeSinceLastAction = 0.0f;
            StaffAction action = Staff.ChooseSomething(staff);
            staff.SetAction(action);
            staff.isAction = true;
            CDebug.PrintAction(staff.action);
            //staff.CompleteAction();
        } else
        if(!staff.HasAction()){
            timeSinceLastAction += GTime.deltaTimeSeconds;
        }
    }
}
