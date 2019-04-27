using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript: MonoBehaviour
{
    public float interactDistance = 7f;
    public GameObject levelFinishUI;
    public bool flag = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                if (hit.collider.CompareTag("Door"))
                {
                    hit.collider.transform.GetComponent<DoorOpen>().ChangeDoorState();
                }

            }
        }

    }
}
