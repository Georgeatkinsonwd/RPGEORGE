using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    public List<GameObject> easyEnemyPooledObjects = new List<GameObject>();
    public int enemiesToPool = 5;

    [SerializeField] private GameObject easyEnemyPrefab;

   
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }



    public GameObject GetEasyEnemyPooledObjects()
    {
        for (int i = 0; i < easyEnemyPooledObjects.Count; i++)
        {
            if (!easyEnemyPooledObjects[i].activeInHierarchy)
            {
                return easyEnemyPooledObjects[i];
            }
        }
        return null;
    }


    public void CreatePoolObjects()
    {
     

        for (int i = 0; i < enemiesToPool; i++)
        {
            GameObject obj = Instantiate(easyEnemyPrefab);
            obj.SetActive(false);
            easyEnemyPooledObjects.Add(obj);
        }
    }
}
