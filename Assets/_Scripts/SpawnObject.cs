using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public static SpawnObject instance;

    public GameObject myPrefabObject = null;

    public bool isSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(KeyPickup.instance.activiateSpawn == true)
        {
            SpawnNextLevel();
            //KeyPickup.instance.activiateSpawn = false;
        }
    }

    public void SpawnNextLevel()
    {
        Instantiate(myPrefabObject, transform.position, Quaternion.identity);
    }
}
