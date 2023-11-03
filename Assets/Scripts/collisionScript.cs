using UnityEngine;
using System.Collections;
using System.Threading;

public class collisionScript : MonoBehaviour
{


    
    void OnTriggerEnter(Collider col)
    {

        if (col.CompareTag("Enemy"))
        {


            for(int i = 0; i < MonsterGenerator.Instance._enemies.Count; i++)
            {
                if (col.gameObject == MonsterGenerator.Instance._enemies[i])
                {
                    MonsterGenerator.Instance._enemies.Remove(col.gameObject);
                }
            }

            GameObject explosion = Instantiate(Resources.Load("FlareMobile(Astroids)", typeof(GameObject))) as GameObject;
            explosion.transform.position = transform.position;
            Destroy(col.gameObject);
            Destroy(explosion, 2);
            Destroy(gameObject);
            GameManager.Instance.Score++;
        }


        //Hasnat's

        if (col.CompareTag("Asteroids"))
        {
            foreach(Transform item in col.transform)
            {
                if(item.name == "S_Ast")
                {
                    item.parent = null;
                    item.gameObject.SetActive(true);
                    item.GetComponent<Rigidbody>().AddExplosionForce(10f, col.transform.position, 50f);
                    MonsterGenerator.Instance._enemies.Add(item.gameObject);
                }
            }
            Destroy(gameObject);
            Destroy(col.gameObject);
            MonsterGenerator.Instance._enemies.Remove(col.gameObject);
        }

        if(col.CompareTag("S_Ast"))
        {
            foreach(Transform item in col.transform)
            {
                item.parent = null;
                item.GetComponent<Rigidbody>().isKinematic = false;
                item.GetComponent<Rigidbody>().AddExplosionForce(150f, col.transform.position, 50f);
                Destroy(item.gameObject, 2f);
            }
            GameObject explosion = Instantiate(Resources.Load("FlareMobile(Astroids)", typeof(GameObject))) as GameObject;
            explosion.transform.position = transform.position;
            Destroy(col.gameObject);
            Destroy(explosion, 2);
            Destroy(gameObject);
            MonsterGenerator.Instance._enemies.Remove(col.gameObject);
            GameManager.Instance.Score++;
        }


        //if (col.CompareTag("Asteroids"))
        //{
        //    for (int i = 0; i < MonsterGenerator.Instance._enemies.Count; i++)
        //    {
        //        if (col.gameObject == MonsterGenerator.Instance._enemies[i])
        //        {
        //            MonsterGenerator.Instance._enemies.Remove(col.gameObject);
        //        }
        //    }

        //    foreach (Transform _child in col.transform)
        //    {
        //        _child.SetParent(null);
        //        _child.GetComponent<Rigidbody>().AddExplosionForce(5f, col.transform.position, 50f);
        //        _child.GetComponent<BoxCollider>().enabled = true;
        //        _child.GetComponent<FolowToCamera>().enabled = true;
        //        _child.GetComponent<Target>().enabled = true;

        //        Vector3 direction = MonsterGenerator.Instance._mainCamera.position - _child.transform.position;
        //        Quaternion rotation = Quaternion.LookRotation(direction);

        //        _child.transform.rotation = rotation;
        //    }
        //    Destroy(col.gameObject);
        //    Destroy(gameObject);
        //}
    }

}

