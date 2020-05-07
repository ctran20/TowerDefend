using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollide : MonoBehaviour
{
    [SerializeField] private GameObject fireFx;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(fireFx, transform.position, transform.rotation);
            collision.gameObject.GetComponent<Enemy>().Hit();
            Destroy(transform.parent.gameObject,0.01f);
        }
    }
}
