using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndScript : MonoBehaviour
{
    public GameObject gameFinishUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            gameFinishUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
