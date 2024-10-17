using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderSpawner : MonoBehaviour
{
    public GameObject prefab;

    public float spawnRate;
    public float waveDuration;
    public float waveInterval;
    private bool spawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWaves());

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
        float rp1 = Random.Range(20f, 50f);

        Vector3 vecP = new Vector3(rp1, 0, 0);
        Quaternion rotation = Quaternion.Euler(90, 90, 0);


        Instantiate(prefab, transform.position+vecP, rotation);
    }


    void Update()
    {
        
    }
}
