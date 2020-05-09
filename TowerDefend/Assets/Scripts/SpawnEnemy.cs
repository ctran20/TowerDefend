using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private int enemyCount = 20;
    [SerializeField] [Range(10, 20)] private float radius = 10;
    [SerializeField] private float spawnTime = 2.5f;

    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        timer = spawnTime;
        for (int i = 0; i < enemyCount; i++)
        {
            float randAngle = Random.Range(0, 2*Mathf.PI);
            Debug.Log(randAngle);
            float x = Mathf.Cos(randAngle)*radius;
            float z = Mathf.Sin(randAngle)*radius;

            Debug.Log("X: " + x);
            Debug.Log("Z: " + z);

            Instantiate(enemy, new Vector3(x, 1.5f, z), Quaternion.identity);

            if(timer > 1)
            {
                timer = timer - 0.1f;
            }

            yield return new WaitForSeconds(timer);
        }

        yield return new WaitForSeconds(10f);
        //AudioManager.PlaySound("levelUp", 1f);
    }
}
