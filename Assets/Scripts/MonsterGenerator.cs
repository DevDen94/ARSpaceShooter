using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] Monster;
    [SerializeField] int minSpawnTime;
    [SerializeField] int maxSpawnTime;

    public float DynamicSpawnTimeChange;

    // Start is called before the first frame update
    void Start()
    {
        minSpawnTime = 1;
        maxSpawnTime = 5;
        

    }


    private void OnEnable()
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


        Instantiate(Monster[Random.Range(0, Monster.Length)], position, Quaternion.identity);
        yield return new WaitForSeconds(0); // for more controll
    }
}
