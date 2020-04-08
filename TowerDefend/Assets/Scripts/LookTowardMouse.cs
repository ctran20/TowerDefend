using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTowardMouse : MonoBehaviour
{
    Vector3 position;

    void Update()
    {
        GetPoint();
        RotateToLook();
    }

    void GetPoint()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000))
        {
            position = hit.point;
            //Debug.Log(position);
        }
    }

    void RotateToLook()
    {
        if (Vector3.Distance(transform.position, position) > 5)
        {
            Quaternion rotation = transform.rotation;

            // ensure that we are looking at the same plane as the character
            //Vector3 p = position;
            //p.y = transform.position.y;
            //transform.LookAt(p);

            transform.LookAt(position);


            transform.rotation = Quaternion.Slerp(rotation, transform.rotation, Time.deltaTime * 30);
        }
    }
}
