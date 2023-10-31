using UnityEngine;
using System.Collections;

public class collisionScript : MonoBehaviour
{


    
    void OnTriggerEnter(Collider col)
    {

        if (col.CompareTag("Enemy"))
        {
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
            foreach (Transform _child in col.transform)
            {
                _child.SetParent(null);
                _child.GetComponent<Rigidbody>().AddExplosionForce(80f, col.transform.position, 50f);
                _child.GetComponent<BoxCollider>().enabled = true;
                _child.GetComponent<FolowToCamera>().enabled = true;
                _child.GetComponent<Target>().enabled = true;
            }
            Destroy(col.gameObject);
            Destroy(gameObject);
        }

    }

}

