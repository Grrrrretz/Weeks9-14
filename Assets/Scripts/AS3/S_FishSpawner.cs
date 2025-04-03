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
            int randomnumSpawn = fishSpawns[Random.Range(0, fishSpawns.Length)];

            float x = Random.Range(-8f, 8f);
            float y = Random.Range(-3f, 3f);
            Vector2 spawnPos = new Vector2(x, y);
            GameObject fishprefab = Fishr[randomnumSpawn];

            GameObject fish = Instantiate(fishprefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        }
    }
}
