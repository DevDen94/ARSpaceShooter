using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenerator : MonoBehaviour
{
    public static MonsterGenerator Instance;

    [SerializeField] GameObject[] Monster;
    [SerializeField] int minSpawnTime;
    [SerializeField] int maxSpawnTime;

    public float DynamicSpawnTimeChange;


    public Transform _mainCamera;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        minSpawnTime = 3;
        maxSpawnTime = 8;
        

    }


    private void OnEnable()
    {
        minSpawnTime = 3;
        maxSpawnTime = 8;
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



        GameObject instatiatedMonster = Instantiate(Monster[Random.Range(0, Monster.Length)], position, Quaternion.identity);

        Vector3 direction = _mainCamera.position - instatiatedMonster.transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);

        instatiatedMonster.transform.rotation = rotation;


        yield return new WaitForSeconds(0); // for more controll
    }
}
