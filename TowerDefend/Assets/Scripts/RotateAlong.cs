using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAlong : MonoBehaviour
{
    [SerializeField] private GameObject anchor;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = new Quaternion(0, anchor.transform.rotation.y, 0, anchor.transform.rotation.w);
    }
}
