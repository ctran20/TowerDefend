using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject player;
    [SerializeField] private int enemyCount = 20;
    [SerializeField] [Range(10, 20)] private float radius = 10;
    [SerializeField] private float spawnTime = 2.5f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            float randAngle = Random.Range(0, 2*Mathf.PI);
            Debug.Log(randAngle);
            float x = Mathf.Cos(randAngle)*radius;
            float z = Mathf.Sin(randAngle)*radius;

            Debug.Log("X: " + x);
            Debug.Log("Z: " + z);

            Instantiate(enemy, new Vector3(x, 1, z), Quaternion.identity);

            yield return new WaitForSeconds(spawnTime - (i / 20));
        }

        yield return new WaitForSeconds(10f);
        //AudioManager.PlaySound("levelUp", 1f);
    }
}
