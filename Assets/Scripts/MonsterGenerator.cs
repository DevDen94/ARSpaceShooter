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

    //For Making Enemies Limited according to time.
    float calculatedTime;
    int currentMaxEnemies = 3;
    readonly int maxEnemies = 8;
    readonly float _seconds = 120;
    int enemiesIncreaseRate = 1;
    public float timePassed;
    Coroutine GeneratorRoutineCR;


    /*[HideInInspector]*/ public List<GameObject> _enemies = new();


    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        calculatedTime = Time.deltaTime; //For Making Enemies Limited according to time.

        minSpawnTime = 2;
        maxSpawnTime = 4;
        

    }


    private void OnEnable()
    {
        minSpawnTime = 2;
        maxSpawnTime = 4;
        StartCoroutine(MainRoutine());

    }

    private void Update()
    {
        DynamicSpawnTimeChange += Time.deltaTime;

        calculatedTime += Time.deltaTime;

        if(_seconds * enemiesIncreaseRate < calculatedTime)
        {
            if (currentMaxEnemies < maxEnemies)
            {
                currentMaxEnemies++;
                enemiesIncreaseRate++;
            }
        }
    }

    IEnumerator MainRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if(_enemies.Count == 0)
            {
                Debug.Log("Main Routine");
                if(GeneratorRoutineCR != null )
                {
                    StopCoroutine(GeneratorRoutineCR);
                }
                GeneratorRoutineCR = StartCoroutine(GenerateRoutine());
            }
        }
    }


    IEnumerator GenerateRoutine()
    {
        for(int i = 0; i <= currentMaxEnemies; i++)
        {
            Vector3 position;
            position.x = Random.Range(-15, 15);
            position.y = Random.Range(-15, 15);
            position.z = Random.Range(-15, 15);

            Debug.Log("Generating routine is working rapidly");

            GameObject instatiatedMonster = Instantiate(Monster[Random.Range(0, Monster.Length)], position, Quaternion.identity);

            _enemies.Add(instatiatedMonster);

            Vector3 direction = _mainCamera.position - instatiatedMonster.transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);

            instatiatedMonster.transform.rotation = rotation;

            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
        }
        //yield return new WaitForSeconds(0); // for more controll
    }
}
