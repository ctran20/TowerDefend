using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollide : MonoBehaviour
{
    [SerializeField] private GameObject fireFx;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground") && !collision.gameObject.CompareTag("Player"))
        {
            Instantiate(fireFx, transform.position, transform.rotation);
            collision.gameObject.GetComponent<Rigidbody>().useGravity = false;
            collision.gameObject.GetComponent<Enemy>().tagged = true;
            Destroy(collision.gameObject, 1f);
            Destroy(transform.parent.gameObject,0.01f);
        }
    }
}
