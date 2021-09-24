using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObjectsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject evil;
    [SerializeField] private GameObject o2cell;
    [SerializeField] private float spawnSpeed;

    private float posX, posY, maxX = 10f, maxY = 6f;

    private float spawnTime, spawnDelay;

    private void Start()
    {
        spawnDelay = 1f / spawnSpeed;
        spawnTime = spawnDelay;
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime && !MenuController.isPause)
        {
            spawnEvil();
            spawnTime = Time.time + spawnDelay;
        }
    }

    void spawnEvil()
    {
        if (Random.Range(-1, 1) == 0)
        {
            posX = maxX * Mathf.Sign(Random.Range(-1, 1));
            posY = Random.Range(-maxY, maxY);
        }
        else
        {
            posX = Random.Range(-maxX, maxX);
            posY = maxY * Mathf.Sign(Random.Range(-1, 1));
        }

        Instantiate(evil, new Vector3(posX, posY, 0), Quaternion.identity);
    }
}
