using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    int notification = 0;

    int bronze, bronzeSupply;
    int silver, silverSupply;
    float mineNow;
    float miningSpeed;

    // Start is called before the first frame update
    void Start()
    {
        bronze = 0;
        silver = 0;
        bronzeSupply = 3;
        silverSupply = 2;
        miningSpeed = 3;
        mineNow = miningSpeed;

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

            }
            else if (silverSupply > 0)
            {
                silverSupply--;
                silver++;

            }
            print("Bronze: " + bronze + "...Silver" + silver);


        }
        if (Time.time > 3 && notification == 0)
        {
            print("It's been three seconds");
            notification = 1;

        }
       // print(Time.time);

    }
}
