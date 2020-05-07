using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float timer = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timer);
    }
}
