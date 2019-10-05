using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    // make it public so things outside GameController can mess with this
    // also if you make it private those outside GameController cant access

    //int notification = 0;

    Vector3 cubePosition;

    public GameObject bronzecubePrefab;
    public GameObject silvercubePrefab;
    public GameObject goldcubePrefab;

    int xPos;
    int yPos;

    int goldSupply;
    int bronzeSupply;
    int silverSupply;
    float mineNow;
    float miningSpeed;

    // Start is called before the first frame update
    void Start()
    {

        xPos = 2;
        yPos = 1;

        goldSupply = 0;
        bronzeSupply = 0;
        silverSupply = 0;
        miningSpeed = 1;
        mineNow = miningSpeed;

    }

    void CreateCube(Vector3 cubePosition, GameObject cubePrefab)
    {
 
        Instantiate(cubePrefab, cubePosition, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > mineNow)
        {
            mineNow += miningSpeed;

           if (bronzeSupply < 4)
           {
                bronzeSupply++;

                CreateCube(cubePosition, bronzecubePrefab);
                cubePosition = new Vector3(xPos, 0, 0);
                xPos += 2;

           }
           // trying to make more cubes appear on screen
           // so i made the int yPos to change the position on where it appears
           // finding it difficult to make them appear on top of the bronze
           else if (bronzeSupply >= 4)
           {

                silverSupply++;
                

                CreateCube(cubePosition, silvercubePrefab);
                cubePosition = new Vector3(xPos, yPos, 0);
                xPos += 2; yPos += 1; 
           }
           // I spent time working on how to construct the gold
           // I eventually got it, all i was missing was the ELSE
           // I used the bronze and silver statements as the structure
           else if (bronzeSupply == 2 && silverSupply == 2)
           {
                goldSupply++;

                CreateCube(cubePosition, goldcubePrefab);
                cubePosition = new Vector3(xPos, 0, 0);
                xPos += 2;
           }
           // i changed it SUPPLY because i wasnt using the other variables
           // bronze silver and gold int
           print("Bronze: " + bronzeSupply + "...Silver" + silverSupply + "Gold" + goldSupply);

        }


        //if (Time.time > 3 && notification == 0)
        {
            //print("It's been three seconds");
            //notification = 1;

        }
       // print(Time.time);

    }
}
