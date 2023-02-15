using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int MaxAllowedEnemies = 20;
    int currnetNumberOfEnemies;
  

    public bool CanSpawnEnemy()
    {
        GameObject[] Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        int currentNumberOfEnemies=Enemy.Length;
        if (currnetNumberOfEnemies < MaxAllowedEnemies)
        {
            return true;
        }
        else 
            return false;
    }
    public void RecordEnemySpawned()
    {
       
    }
    public void RecordEnemyDestroyed()
    {

    }
    
}
