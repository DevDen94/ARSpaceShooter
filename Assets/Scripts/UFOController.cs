using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    public float stoppingDist;
    public float Speed;
    public float BulletDelay;
    public float BulletStartDelay;
    public GameObject Bullet;
    public Transform BulletSpawnner;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FiringDelay());
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(transform.position, Camera.main.gameObject.transform.position);

        if (dis > stoppingDist)
        {
            transform.LookAt(Camera.main.gameObject.transform.position);
            transform.Translate(Speed * Time.deltaTime * Vector3.forward);
        }
    }

    IEnumerator FiringDelay()
    {
        while (true)
        {
            if (Vector3.Distance(transform.position, Camera.main.gameObject.transform.position) < stoppingDist)
            {
                yield return new WaitForSeconds(BulletStartDelay);

                StartCoroutine(Firing());

                yield break;
            }
        }

        
    }

    IEnumerator Firing()
    {
        while (true)
        {
            Instantiate(Bullet, BulletSpawnner.position, BulletSpawnner.rotation);

            yield return new WaitForSeconds(BulletDelay);
        }
    }
}
