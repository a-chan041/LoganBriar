using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu2 : MonoBehaviour
{
    void OnGUI()
    {
        if (GUI.Button(new Rect(0,0, 120, 70), "Back to Menu"))
        //if (GUI.Button(new Rect(100, 50, 60, 60), "Back to Menu"))
        {
#pragma warning disable CS0618 // Type or member is obsolete
            Application.LoadLevel(0);
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }

}
