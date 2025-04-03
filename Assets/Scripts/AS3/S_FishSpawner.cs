using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_FishSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Fishr;
    public int[] fishSpawns;
    void Start()
    {
        StartCoroutine(SpawnFish());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnFish() 
    {
        while (true)
        {
            int randomnumSpawn = fishSpawns[UnityEngine.Random.Range(0, fishSpawns.Length)];

            float x = UnityEngine.Random.Range(-8f, 8f);
            float y = UnityEngine.Random.Range(-4f, 4f);
            Vector2 spawnPos = new Vector2(x, y);
            GameObject fishprefab = Fishr[randomnumSpawn];

            GameObject fish = Instantiate(fishprefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f, 1.5f));
        }
    }
}
