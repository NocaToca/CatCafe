using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    /*The Main Cat Script. This has a lot, or is going to*/
    public new string name;

    [Header("Public Stats")]
    public float age;
    public float stamina;

    [Header("Stat Alteration")]
    public float happinessDecay = 20.0f;

    [Header("Need Growth")]
    public float hungerGrouth = 100.0f;
    public float thirstGrowth = 75.0f;
    public float sleepGrowth = 150.0f;
    public float peeGrowth = 750.0f;
    public float poopGrowth = 1500.0f;

    [Header("Misc")]
    public float detectionDistance = 10.0f;
    public float actionInterval = 100.0f; 

    [HideInInspector]
    public float happiness = 100.0f;
    [HideInInspector]
    public float scratchItch = 0.0f;

    /************Health Stats*************/
    [HideInInspector]
    public float hunger = 0.0f;
    [HideInInspector]
    public float thirst = 0.0f;
    [HideInInspector]
    public float drowsiness = 0.0f;
    [HideInInspector]
    public float pee = 0.0f;
    [HideInInspector]
    public float poop = 0.0f; //LOL

    [HideInInspector]
    public float weight;

    [HideInInspector]
    public float speed = 1.0f;

    public CatAction action;
    public bool isAction;

    private CatStats stats;

    //if someone wants to access our stats let's make sure they can't edit them (at least without our permission!)
    public float friendliness{get{return stats.friendliness;}} 
    public float dominance{get{return stats.dominance;}} 
    public float playfullness{get{return stats.playfullness;}}
    public float skittishness{get{return stats.skittishness;}}
    public float socialibility{get{return stats.socialibility;}}
    public float spontaneity{get{return stats.spontaneity;}}

    // Start is called before the first frame update
    void Start(){
        Cat.CreateCat(this);
        //DebugPrintStats();
        if(happinessDecay < 1.0f){
            Debug.LogWarning("Happiness Decay on" + name + "was less than one. Negative values are not accepted. Set to 1.0f");
            happinessDecay = 1.0f;
        }

        speed = 1.0f;
    }

    // Update is called once per frame
    void Update(){
        UpdateHappiness();
        UpdateNeeds();
    }

    protected virtual void UpdateNeeds(){
        hunger += GTime.deltaTimeSeconds/hungerGrouth;
        thirst += GTime.deltaTimeSeconds/thirstGrowth;
        drowsiness += GTime.deltaTimeSeconds/sleepGrowth;
        pee += GTime.deltaTimeSeconds/peeGrowth;
        poop += GTime.deltaTimeSeconds/poopGrowth;
    }

    protected virtual void UpdateHappiness(){
        happiness -= CAlgorithms.CalculateWeightedHappiness(happiness, hunger, thirst, drowsiness, pee, poop)/happinessDecay * GTime.deltaTimeSeconds;
        happiness = CAlgorithms.Clamp0Val(happiness, 100.0f);
        //happiness -= GTime.deltaTimeSeconds/happinessDecay;
    }

    public virtual void UpdateHappiness(CatAction action){
        happiness += CAlgorithms.CalculateHappinessIncrease(this, action);
        happiness = CAlgorithms.Clamp0Val(happiness, 100.0f);
    }

    protected void SetStats(CatStats stats){
        this.stats = stats;
    }

    public void SetAction(CatAction action){
        this.action = action;
    }
    public void CompleteAction(){
        action.gameObject.DoAction(this);
        action = new CatAction(null, "None");
        isAction = false;
    }

    public bool HasAction(){
        return isAction;
    }

    

    public static CatAction ChooseSomething(Cat cat){
        List<GameObject> closeObjects = new List<GameObject>();

        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>() ;
        foreach(GameObject go in allObjects){
            if (go.activeInHierarchy){
                if(Vector3.Distance(cat.transform.position, go.transform.position) < cat.detectionDistance){
                    closeObjects.Add(go);
                }
            }
        }
            
        return CAlgorithms.FindObjectToInteractWith(cat, closeObjects);
    }

    public static Cat CreateCat(Cat cat){
        
        //Lets get our stats
        float[] stats = new float[6];
        for(int i = 0; i < stats.Length; i++){
            float f = Random.Range(-1000, 1000);
            f /= 1000.0f;
            stats[i] = f;
        }

        cat.SetStats(new CatStats(stats[0], stats[1], stats[2], stats[3], stats[4], stats[5]));
        return cat;
    }


    protected struct CatStats{
        public readonly float friendliness; //stat towards people
        public readonly float dominance; //stat towards cats
        public readonly float playfullness;
        public readonly float skittishness;
        public readonly float socialibility;

        public readonly float spontaneity; //Determines outbursts. Most noticeable in non-playful cats

        public CatStats(float f, float d, float p, float sk, float so, float sp){
            friendliness = f;
            dominance = d;
            playfullness = p;
            skittishness = sk;
            socialibility = so;
            spontaneity = sp;
        }
    }

}

