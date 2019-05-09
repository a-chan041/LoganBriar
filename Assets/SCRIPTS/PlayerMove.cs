﻿using UnityEngine;
using System.Collections;

// The GameObject is made to bounce using the space key.
// Also the GameOject can be moved forward/backward and left/right.
// Add a Quad to the scene so this GameObject can collider with a floor.

public class PlayerMove : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public AudioSource audio;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // let the gameObject fall down
        gameObject.transform.position = new Vector3(0, 5, 0);
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;

           if (Input.GetButton("Jump"))
            {
               moveDirection.y = jumpSpeed;
           }
        }

        // Apply gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);

        // steps by Clay
        if ((moveDirection.x != 0 || moveDirection.z != 0) && audio.isPlaying == false)
        {
            audio.Play();
        }
        else if (moveDirection.x == 0 && moveDirection.z == 0)
        {
            audio.Stop();
        }
    }
}
