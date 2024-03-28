using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public List<ItemData> availableItems;
    public ItemDisplayer itemPrefab;
    

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnObject();

        }
    }

    private void SpawnObject()
    {
        ItemData selectData = availableItems[UnityEngine.Random.Range(0, availableItems.Count - 1)];
        ItemDisplayer spawnedObject = Instantiate(itemPrefab);
        spawnedObject.transform.position = new Vector3(0, 0.5f, 3);

        spawnedObject.Display(selectData.name, selectData.icon);
    }
}
