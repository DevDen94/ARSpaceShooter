using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpKinGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] Pumpkin;
    [SerializeField] int minSpawnTime;
    [SerializeField] int maxSpawnTime;

    public float DynamicSpawnTimeChange;

    // Start is called before the first frame update
    void Start()
    {
        minSpawnTime = 1;
        maxSpawnTime = 5;
        StartCoroutine(MainRoutine());

    }

    private void Update()
    {
        DynamicSpawnTimeChange += Time.deltaTime;
    }

    IEnumerator MainRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            StartCoroutine(GenerateRoutine());
        }
            
        
    }


    IEnumerator GenerateRoutine()
    {
        Vector3 position;
        position.x = Random.Range(-15, 15);
        position.y = Random.Range(-15, 15);
        position.z = Random.Range(-15, 15);


        Instantiate(Pumpkin[Random.Range(0,Pumpkin.Length)], position, Quaternion.identity);
        yield return new WaitForSeconds(0);
    }


}
