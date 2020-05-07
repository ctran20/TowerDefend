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

    public void GetPoint()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000))
        {
            position = hit.point;
            //Debug.Log(position);
        }
    }

    public void RotateToLook()
    {
        if (Vector3.Distance(transform.position, position) > 5)
        {
            Quaternion rotation = transform.rotation;
            transform.LookAt(position);
            transform.rotation = Quaternion.Slerp(rotation, transform.rotation, Time.deltaTime * 38);
        }
    }
}
