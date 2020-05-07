using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int minDist = 2;
    [SerializeField] int moveSpeed = 10;

    GameObject player;
    public bool tagged;

    private void Start()
    {
        tagged = false;
        player = GameObject.FindGameObjectWithTag("Player");
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
}
