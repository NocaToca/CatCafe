using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adoption{

    //parameters (mostly the cat script and the customer script)
    //public float popularity
    //Adoption type
    /*public Adoption(Cat cat, Customer customer){
        //Set initial variables

        //Initialize the popularity float

        //Create the adoption type
    }*/

    //Initialize popularity function.
    /*
        First, we would have to compare the personality match between the customer and cat. This is, after all, the main driving first (poor personality match cannot be outdone by great houseing match)

        Next, we'd determine the housing match. This is everything like being good with dogs or not. The ones that weight the most (in order):
        -Works well with other animals
        -Works well with children
        -Works well with setting (urban, rural, suburb)
        -Allergies
        -Income

        The housing will decrement the personality match meaning that it will not increase from the personality match value and can only decrease
    */ 

    //Creating the adoption type
    /*
        We'll have weights declared uptop that are static. These can be set in the "GameMode" gameobject

        Basically we have to think about the gameplay here:
        -When should we have customers with no cat requirement?
        -When should we have customers with super specific requirements?

        This will be based off of how well the previous adoptions went, and what the previous offers were
    */

    /*static Adopt(Adoption adopt)
        Basically just makes the cat get adopted and adds to the popularity score
    */
}

