using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject ship;
    public GameObject startPanel;
    public int enemiesToSpawnMin = 2;
    public int enemiesToSpawnMax = 10;
    public float spawnInterval = 0.5f;
    public float timeBetweenBatches = 6f;

    private int enemiesToSpawn;
    private int enemiesSpawned;
    private float maxRadius;
    private int direction;
    private float spawnTimer;
    private float waitTimer;
    private bool waiting;

    // Start is called before the first frame update
    void Start()
    {
        enemiesToSpawn = Random.Range(enemiesToSpawnMin, enemiesToSpawnMax + 1);
        enemiesSpawned = 0;
        spawnTimer = 0f;
        direction = Random.Range(0, 2) * 2 - 1;
        maxRadius = Vector3.Distance(transform.position, ship.transform.position);
        waiting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startPanel.activeInHierarchy)
            return;

        if (waiting)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= timeBetweenBatches)
            {
                waitTimer = 0f;
                enemiesToSpawn = Random.Range(enemiesToSpawnMin, enemiesToSpawnMax + 1);
                enemiesSpawned = 0;
                direction = Random.Range(0, 2) * 2 - 1;
                waiting = false;
            }
        }
        else
        {
            spawnTimer += Time.deltaTime;
            if (enemiesSpawned < enemiesToSpawn && spawnTimer >= spawnInterval)
            {
                spawnTimer = 0f;
                GameObject enemyInstance = Instantiate(enemyPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
                enemyInstance.GetComponent<Enemy>().maxRadius = maxRadius;
                enemyInstance.GetComponent<Enemy>().direction = direction;
                enemiesSpawned++;
            }
            else if (enemiesSpawned >= enemiesToSpawn && spawnTimer >= spawnInterval)
            {
                waiting = true;
            }
        }
    }
}
