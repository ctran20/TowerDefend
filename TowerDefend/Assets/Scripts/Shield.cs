using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private GameObject fireFx;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(fireFx, collision.gameObject.transform.position, transform.rotation);
            collision.gameObject.GetComponent<Enemy>().Hit();
        }
    }
}
