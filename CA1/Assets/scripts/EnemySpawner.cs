using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    GameManager gameManager;
    public GameObject Enemy1Prefab;
    public GameObject Enemy2Prefab;
    public float spawnTime = 2;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("GameController");
        GetComponent<GameManager>();
        InvokeRepeating("SpawnEnemy",spawnTime, spawnTime);
       
    }

    // Update is called once per frame
    void SpawnEnemy()
    {
        int chose =Random.Range(1, 10);
        chose = chose % 2;
        if (chose == 0)
        {
            Instantiate(Enemy1Prefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(Enemy2Prefab, transform.position, Quaternion.identity);
        }

        
    }
}
