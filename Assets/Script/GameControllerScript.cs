using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    Vector3 cubePosition;
    public GameObject cubePrefab;
    Ore recentOre;
    GameObject myCube;

    float xPos;
    float yPos;

    //static means single variable that we are keeping track of called bronzeSupply etc
    
    public static int goldSupply;
    public static int bronzeSupply;
    public static int silverSupply;
    public static int points, bronzePoints, silverPoints, goldPoints;

    float mineNow;
    float miningSpeed;

    // Start is called before the first frame update
    void Start()
    {

        xPos = -5;
        yPos = -4;

        goldSupply = 0;
        bronzeSupply = 0;
        silverSupply = 0;
        bronzePoints = 1;
        silverPoints = 10;
        goldPoints = 100;

        miningSpeed = 3;
        mineNow = miningSpeed;
         
        recentOre = Ore.Bronze;

    }

    // I can create a method in GameController rather than cubecontroller because
    // the gamecontroller should be keeping track of and modifying the points
    public static void ProcessClickedCube(Ore ore)
    {
        if (ore == Ore.Bronze)
        {

            bronzeSupply--;
            points += bronzePoints;

        }
        else if (ore == Ore.Silver)
        {

            silverSupply--;
            points += silverPoints;

        }
        else
        {

            goldSupply--;
            points += goldPoints;

        }
    }

    void CreateCube(Ore ore)
    {
        Color cubeColor;

        if(ore == Ore.Bronze)
        {
            cubeColor = Color.red;
        }
        else if(ore == Ore.Silver)
        {
            cubeColor = Color.white;
        }
        else
        {
            cubeColor = Color.yellow;
        }

        cubePosition = new Vector3(xPos, yPos, 0);
        myCube = Instantiate(cubePrefab, cubePosition, Quaternion.identity);
        myCube.GetComponent<Renderer>().material.color = cubeColor;
        myCube.GetComponent<CubeController>().myOre = ore;

        // i got these positions from the video and that helps create
        // more cubes on my screen
        xPos += 2;
        if(xPos > 6)
        {
            xPos = -5;
            yPos += 2;
        }
        recentOre = ore;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > mineNow)
        {
            mineNow += miningSpeed;

            // at first i did not know how to call the method
            // when i saw the video i finally understood that you have to type 
            // everything inside the method and then call on it right here
            if (bronzeSupply == 2 && silverSupply == 2 && recentOre != Ore.Gold )
            {
                goldSupply++;
                CreateCube(Ore.Gold);
                
            }

            else if (bronzeSupply < 4)
            {

                bronzeSupply++;
                CreateCube(Ore.Bronze);

            }
      
           else if (bronzeSupply >= 4)
           {

                silverSupply++;
                CreateCube(Ore.Silver);

           }
           // i changed it SUPPLY because i wasnt using the other variables
           // bronze silver and gold int

            // i dont need to print it because we see the cubes appear on screen
            // i can delete it but i will make it a comment
           // print("Bronze: " + bronzeSupply + "...Silver" + silverSupply + "Gold" + goldSupply);

           print("Total Points: " + points);
        }

    }
}
