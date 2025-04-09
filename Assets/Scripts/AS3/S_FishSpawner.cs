using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class S_FishSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Fishr;
    public int[] fishSpawns;

    public S_Score Score;
    public S_GoodTime GoodTime;
    void Start()
    {
        StartCoroutine(SpawnFish());//Spawn the fish.
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SpawnFish() 
    {
        while (true)
        {
            int randomnumSpawn = fishSpawns[Random.Range(0, fishSpawns.Length)];//Create an array for random fish generation and allow control over the spawn probability.
            //Randomly generate the spawn position.
            float x = Random.Range(-8f, 8f);
            float y = Random.Range(-3f, 3f);
            Vector2 spawnPos = new Vector2(x, y);
            GameObject fishprefab = Fishr[randomnumSpawn];
            //Instantiate the prefab.
            GameObject fish = Instantiate(fishprefab, spawnPos, Quaternion.identity);
            //Get the instantiated prefab and add listeners to them, waiting for later triggers.
            S_Fish NewFish = fish.GetComponent<S_Fish>();




                NewFish.smallfish.AddListener(Score.GetSmallFish);//Notify the Score script that a small fish has been caught.Score should +1
            NewFish.smallfish.AddListener(GoodTime.GoodTiming);//Trigger the combo catch check in the Good Time system.

            NewFish.bigfish.AddListener(Score.GetBigFish);//Notify the Score script that a big fish has been caught.Score should +3
            NewFish.bigfish.AddListener(GoodTime.GoodTiming);//Trigger the combo catch check in the Good Time system.


            NewFish.badfish.AddListener(Score.GetBadFish);//Notify the Score script that a bad fish has been caught.Score should -2



            yield return new WaitForSeconds(Random.Range(0.1f, 1f));//Set a random spawn interval.
        }
    }
}
