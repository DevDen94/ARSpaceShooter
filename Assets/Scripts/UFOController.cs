using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOController : MonoBehaviour
{
    public float _stoppingDist;
    public float _speed;
    public float _bulletDelay;
    public float _bulletStartDelay;
    public GameObject _bullet;
    public Transform _bulletSpawnner;

    bool isFiring;

    void Update()
    {
        float dis = Vector3.Distance(transform.position, Camera.main.gameObject.transform.position);

        if (dis > _stoppingDist)
        {
            transform.LookAt(Camera.main.gameObject.transform.position);
            transform.Translate(_speed * Time.deltaTime * Vector3.forward);
        }
        else
        {
            if(!isFiring)
            {
                isFiring = true;
                StartCoroutine(Firing());
            }
        }
    }

    IEnumerator Firing()
    {
        while (true)
        {
            Instantiate(_bullet, _bulletSpawnner.position, _bulletSpawnner.rotation);
            yield return new WaitForSeconds(_bulletDelay);
        }
    }
}
