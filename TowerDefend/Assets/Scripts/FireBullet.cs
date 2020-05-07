using UnityEngine;
using System.Collections;

public class FireBullet : MonoBehaviour
{
    [SerializeField] private ParticleSystem fireFx;
    [SerializeField] private GameObject bullet;

    private bool coolDown;

    private void Start()
    {
        coolDown = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && coolDown)
        {
            coolDown = false;
            StartCoroutine(Fire());
            
        }
    }

    IEnumerator Fire()
    { 
        yield return new WaitForSeconds(0.1f);
        coolDown = true;
        fireFx.Play();
        Instantiate(bullet, transform.position, transform.rotation);
    }
}
