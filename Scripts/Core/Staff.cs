using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Our main staff class. They clean!
public class Staff : MonoBehaviour
{
    public float detectionDistance = 100.0f;
    public float actionInterval = 100.0f;

    public StaffAction action;
    public bool isAction;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void SetAction(StaffAction action){
        this.action = action;
    }

    public bool HasAction(){
        return isAction;
    }

    public void CompleteAction(){
        action.gameObject.DoAction(this);
        action = new StaffAction(null, "None");
        isAction = false;
    }

    public static StaffAction ChooseSomething(Staff staff){
        List<GameObject> closeObjects = new List<GameObject>();

        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>() ;
        foreach(GameObject go in allObjects){
            if (go.activeInHierarchy){
                if(Vector3.Distance(staff.transform.position, go.transform.position) < staff.detectionDistance){
                    closeObjects.Add(go);
                }
            }
        }
            
        return CAlgorithms.FindObjectToInteractWith(staff, closeObjects);
    }
}
