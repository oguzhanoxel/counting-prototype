using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 origin;
    private Vector3 difference;
    private Vector3 resetCamera;

    private bool drag = false;

    private float upperBound = 70;
    private float lowerBound = 5;


    // Start is called before the first frame update
    void Start()
    {
        resetCamera = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            difference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
            if (drag == false)
            {
                drag = true;
                origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            drag = false;
        }

        if (drag)
        {
            float a = origin.y - difference.y;
            if (a < upperBound && a > lowerBound)
            {
                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, a, Camera.main.transform.position.z);
            }
        }

        if (Input.GetMouseButton(1))
        {
            Camera.main.transform.position = resetCamera;
        }
    }
}
