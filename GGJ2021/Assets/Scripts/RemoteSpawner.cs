using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteSpawner : MonoBehaviour
{
    //gameobject for spawning 
    public GameObject spawnObj;
    public float MinX = -0.5f;
    public float MaxX = 1.2f;
    public float Y = 5.7779f;
    public float Z = -5.09f;

    private void Start() 
    {
        SpawnObject();
    }
    void SpawnObject()
    {
        float x = Random.Range(MinX,MaxX);
        var remote = Instantiate(spawnObj, new Vector3(x,Y,Z), Quaternion.identity) as GameObject;
    }
}
