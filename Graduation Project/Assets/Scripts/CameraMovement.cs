using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 dragOrigin;

    // Update is called once per frame
    void Update()
    {
        PanCamera();
        MoveCamera();
    }

    private void PanCamera()
    {
        //Mouse position first time clicked;
        if (Input.GetMouseButtonDown(0))
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);

        //Calculates distance between drag origin and new position
        if (Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);

            if(InBounds(difference))
            cam.transform.position += difference;
        }
    }

    private bool InBounds(Vector3 increase)
    {
        Vector3 newPosition = cam.transform.position + increase;

        if (newPosition.x == cam.transform.position.x && newPosition.y > -0.6 && newPosition.y < 4.65)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void MoveCamera()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Vector3 difference = new Vector3(0, 1f, 0);

            if (InBounds(difference))
            {
                cam.transform.position += difference;
            }
            else
            {
                cam.transform.position = new Vector3(cam.transform.position.x, 4.65f, cam.transform.position.z);
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 difference = new Vector3(0, -1f, 0);

            if (InBounds(difference))
            {
                cam.transform.position += difference;
            }
            else
            {
                cam.transform.position = new Vector3(cam.transform.position.x, -0.6f, cam.transform.position.z);
            }
        }
    }
}
