using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int minDist = 3;
    [SerializeField] int moveSpeed = 10;
    [SerializeField] int health = 1;

    GameObject player;
    public bool tagged;

    private void Start()
    {
        tagged = false;
        player = GameObject.FindGameObjectWithTag("Center");
    }

    // Update is called once per frame
    void Update()
    {
        if (player && !tagged)
        {
            transform.LookAt(player.transform);
            if(Vector3.Distance(transform.position, player.transform.position) >= minDist)
            {
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
            }
            else
            {
                tagged = true;
            }
        }
    }

    public void Hit()
    {
        if(health > 1)
        {
            health--;
            transform.position -= transform.forward;
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            tagged = true;
            Destroy(gameObject, 1f);
        }
    }
}
