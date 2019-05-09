﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PLAYERCONTROLLER : MonoBehaviour
{

    public float speed;

    private Vector3 direction;
    private Rigidbody rbody;

    private float rotationSpeed = 3f;
    private float minY = -60f;
    private float maxY = 60f;
    private float rotationY = 10f;
    private float rotationX = 0f;

    public AudioSource audio;
    //chnages by vishakha
    public Text keycountText;
    public Text flashlightCountText; 
    private int keyCount;
    private int flashlightCount;
    //int keyCount = Singelton.SharedInstance.keyCount;
    //int flashlightCount = Singelton.SharedInstance.flashlightCount; 
    //for loading the canvas for level 1 finsh menu
    public static bool GameComplete = false;
    public GameObject levelFinishUI;
    public static Vector3 playerPos;

    // Use this for initialization
    void Start()
    {
        speed = 5.0f;
        rbody = GetComponent<Rigidbody>();
        keyCount = 0;    // changes by vishakha
        flashlightCount = 0; // changes by vishakha         SetCountText(); // changes by vishakha
        audio = GetComponent<AudioSource>();
        StartCoroutine(TrackPlayer());

    }

    IEnumerator TrackPlayer()
    {
        while (true)
        {
            playerPos = gameObject.transform.position;
            yield return null;
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        direction = Vector3.zero;
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        direction = direction.normalized;
        if (direction.x != 0)
            rbody.MovePosition(rbody.position + transform.right * direction.x * speed * Time.deltaTime);
        if (direction.z != 0)
            rbody.MovePosition(rbody.position + transform.forward * direction.z * speed * Time.deltaTime);

        rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * rotationSpeed;
        rotationY += Input.GetAxis("Mouse Y") * rotationSpeed;
        rotationY = Mathf.Clamp(rotationY, minY, maxY);
        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

         //changes by vishakha
        float moveHorizontal = Input.GetAxis("Horizontal"); 
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rbody.AddForce(movement * 10.0f);

        // steps by Clay
        if ((movement.x != 0 || movement.z != 0) && audio.isPlaying == false)
        {
            audio.Play();
        }
        else if (movement.x == 0 && movement.z == 0)
        {
            audio.Stop();
        }

    }

    //changes by vishakha
    void OnTriggerEnter(Collider other)     {         if (other.gameObject.CompareTag("Pick Up")) // for keys         {             other.gameObject.SetActive(false);             keyCount = keyCount + 1;             SetCountText();         }

        if (other.gameObject.CompareTag("PickUp2"))   // for lighter
        {
            other.gameObject.SetActive(false);
            flashlightCount = flashlightCount + 1;
            SetCountText();
        }

        if (other.gameObject.CompareTag("Caught"))
        {
            SceneManager.LoadScene("Menu");
        }     }
    //changes by vishakha     void SetCountText()     {         keycountText.text = "Keys: " + keyCount.ToString();
        flashlightCountText.text = "FlashLight: " + flashlightCount.ToString();         if (keyCount >= 1 && flashlightCount>=1)         {
            GameComplete = true;
        }     }

     //changes by vishakha
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.M))
            {
                if (GameComplete)
                {
                 levelFinishUI.SetActive(true);
                 Time.timeScale = 0f;
                 GameComplete = false;
                }
            }
    }
}
