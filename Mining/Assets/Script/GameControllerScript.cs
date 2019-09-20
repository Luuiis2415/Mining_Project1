using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    int notification = 0;

    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > 3 && notification == 0)
        {
            print("It's been three seconds");
            notification = 1;

        }
       // print(Time.time);

    }
}
