using UnityEngine;
using System.Collections;

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
                else
                {
                    Debug.Log("No it is not in the List");
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
            for (int i = 0; i < MonsterGenerator.Instance._enemies.Count; i++)
            {
                if (col.gameObject == MonsterGenerator.Instance._enemies[i])
                {
                    MonsterGenerator.Instance._enemies.Remove(col.gameObject);
                }
                else
                {
                    Debug.Log("No it is not in the List");
                }
            }

            foreach (Transform _child in col.transform)
            {
                _child.SetParent(null);
                _child.GetComponent<Rigidbody>().AddExplosionForce(5f, col.transform.position, 50f);
                _child.GetComponent<BoxCollider>().enabled = true;
                _child.GetComponent<FolowToCamera>().enabled = true;
                _child.GetComponent<Target>().enabled = true;

                Vector3 direction = MonsterGenerator.Instance._mainCamera.position - _child.transform.position;
                Quaternion rotation = Quaternion.LookRotation(direction);

                _child.transform.rotation = rotation;
            }
            Destroy(col.gameObject);
            Destroy(gameObject);
        }

    }

}

