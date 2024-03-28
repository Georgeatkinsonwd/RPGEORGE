using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public int enemyCount = 0;
    

    private float spawnRangeX = 20;
    private float spawnZRange = 20;
    private float numberOfEnemies = 2;
    



    public void SpawnEnemies()
    {

        for (int i = 0; i < numberOfEnemies; i++)
        {
            GameObject enemies = ObjectPool.instance.GetEasyEnemyPooledObjects();
            if (enemies != null)
            {
                Enemy currentEnemy = enemies.GetComponent<Enemy>();
                currentEnemy.spawnManager = this;
                enemies.transform.position = GenerateRandomPosition();
                enemies.SetActive(true);
                enemyCount = 0;

            }
                
        }

    }

    
    public void RespawnEnemies()
    {
        if (enemyCount == 2)
        {
            enemyCount = 0;
            SpawnEnemies();
            
        }
       

    }

    public Vector3 GenerateRandomPosition()
    {
        

        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(-spawnZRange, spawnZRange);
        Vector3 calculatedPositon = new Vector3(xPos, 1, zPos);

        return calculatedPositon;


    }
}
