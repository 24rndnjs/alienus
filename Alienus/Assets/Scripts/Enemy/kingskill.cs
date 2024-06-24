using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kingskill : MonoBehaviour
{
    public GameObject Enemy;
    void SpawnEnemy()
    {
        Vector3 playerPosition = GameObject.FindWithTag("boss").transform.position;
        float randomX = Random.Range(-2f, 2f);
        float randomZ = Random.Range(-2f, 2f);
        GameObject enemy=Instantiate(Enemy,new Vector3(playerPosition.x+randomX,playerPosition.y,playerPosition.z+randomZ),Quaternion.identity);
    }
     void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, 15f);
    }
}
