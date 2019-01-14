using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 10f;
    public Transform[] spawnPoints;

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    // Update is called once per frame
    private void Spawn()
    {

        foreach (Transform spawnPoint in spawnPoints)
        {
            Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
