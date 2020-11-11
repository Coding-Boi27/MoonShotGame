using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player; 

    private Vector3 offset = new Vector3(-2, 0); 

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position - offset, Quaternion.identity);
        enemy.GetComponent<EnemyAI>().SetPlayer(player);
    }
}
