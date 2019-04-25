using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu2 : MonoBehaviour
{
    //    void OnGUI()
    //    {
    //        if (GUI.Button(new Rect(0,0, 120, 70), "Back to Menu"))
    //        //if (GUI.Button(new Rect(100, 50, 60, 60), "Back to Menu"))
    //        {
    //#pragma warning disable CS0618 // Type or member is obsolete
    //            Application.LoadLevel(0);
    //#pragma warning restore CS0618 // Type or member is obsolete
    //    }
    //}


    public void LoadLevel1()
    {
        //Time.timeScale = 1f;
        //SceneManager.LoadScene("MainMenu");
        Application.LoadLevel(2);  // replay level 1
    }

    public void LoadLevel2()
    {
        //Time.timeScale = 1f;
        //SceneManager.LoadScene("MainMenu");
        Application.LoadLevel(3);  // next level 2
    }

    public void LoadMenu()
    {
        //Time.timeScale = 1f;
        //SceneManager.LoadScene("MainMenu");
        //Application.LoadLevel(0);  // main menu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
