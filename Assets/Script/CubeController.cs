using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public Ore myOre;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Destroy(gameObject);

        // can call GameControllerScript dot whatever the variable is 
        //because i made them public static
        // can access it from anywhere

        GameControllerScript.ProcessClickedCube(myOre);



        //Instead of all of this we can do that on top, to call the method in gamecontroller

        //if(myOre == Ore.Bronze)
        //{

            //GameControllerScript.bronzeSupply--;
            //GameControllerScript.points += GameControllerScript.bronzePoints;

        //}
       // else if (myOre == Ore.Silver)
        //{

           // GameControllerScript.silverSupply--;
           // GameControllerScript.points += GameControllerScript.silverPoints;

      //  }
        //else
       // {

            //GameControllerScript.goldSupply--;
            //GameControllerScript.points += GameControllerScript.goldPoints;

        //}
    }
}
