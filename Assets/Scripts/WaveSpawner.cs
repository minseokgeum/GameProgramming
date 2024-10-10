using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject prefab;
    //public float startTime;
    //public float endTime;
    public float spawnRate;
    public float waveDuration;
    public float waveInterval;
    private bool spawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWaves());
        //InvokeRepeating("Spawn", startTime, spawnRate);
        //Invoke("CancelInvoke", endTime);
    }
    IEnumerator SpawnWaves()
    {
        while (true)
        {
            spawning = true;
            float waveEndTime = Time.time + waveDuration;
            while (Time.time < waveEndTime)
            {
                Spawn();
                yield return new WaitForSeconds(spawnRate);
            }
            spawning = false;
            yield return new WaitForSeconds(waveInterval);
        }
    }
    void Spawn(){
        float rp1 = Random.Range(-25f, 25f);
        float rp2 = Random.Range(-25f, 25f);
        float randomYRotation = Random.Range(0f, 360f);

        Vector3 vecP = new Vector3(rp1, 0, rp2);
        Quaternion rotation = Quaternion.Euler(0, randomYRotation, 0);

        Instantiate(prefab, transform.position+vecP, rotation);
    }


    void Update()
    {
        
    }
}
