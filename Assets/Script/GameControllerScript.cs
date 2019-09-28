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

    int xPos;

    int bronze, bronzeSupply;
    int silver, silverSupply;
    float mineNow;
    float miningSpeed;

    // Start is called before the first frame update
    void Start()
    {

        xPos = 2;

        bronze = 0;
        silver = 0;
        bronzeSupply = 3;
        silverSupply = 2;
        miningSpeed = 3;
        mineNow = miningSpeed;

    }

    void CreateCube(Vector3 cubePosition, GameObject cubePrefab)
    {
 
        Instantiate(cubePrefab, cubePosition, Quaternion.identity);
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > mineNow && silverSupply != 0)
        {
            mineNow += miningSpeed;
            if (bronzeSupply > 0)
            {
                bronzeSupply--;
                bronze++;

                CreateCube(cubePosition, bronzecubePrefab);
                cubePosition = new Vector3(xPos, 0, 0);
                xPos += 2;
            }
            else if (silverSupply > 0)
            {

                silverSupply--;
                silver++;

                CreateCube(cubePosition, silvercubePrefab);
                cubePosition = new Vector3(xPos, 0, 0);
                xPos += 2;
            }
            print("Bronze: " + bronze + "...Silver" + silver);

        }


        //if (Time.time > 3 && notification == 0)
        {
            //print("It's been three seconds");
            //notification = 1;

        }
       // print(Time.time);

    }
}
