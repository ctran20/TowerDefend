using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int minDist = 3;
    [SerializeField] int moveSpeed = 10;
    [SerializeField] int health = 1;

    GameObject player;
    bool tagged;
    bool hit;
    float scale;

    private void Start()
    {
        scale = 1;
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

        if (hit)
        {
            scale -= 0.005f;
            gameObject.transform.localScale = new Vector3(scale, scale, scale);
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
            gameObject.GetComponent<BoxCollider>().enabled = false;
            tagged = true;
            hit = true;
            Destroy(gameObject, 1f);
        }
    }
}
