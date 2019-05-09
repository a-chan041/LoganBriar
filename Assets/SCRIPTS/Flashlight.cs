using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    new Light light;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if(light.enabled==false)
            {
                light.enabled = true;
                         
            }
            else
            {
                light.enabled = false;
            }
        }
    }
}
