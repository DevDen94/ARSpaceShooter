using UnityEngine;
using System.Collections;
using System.Threading;

public class PlayerBulletScript : MonoBehaviour
{
    
    void OnTriggerEnter(Collider col)
    {

        if (col.CompareTag("Enemy"))
        {
            //string colorCode = col.GetComponent<UFOController>().colorName;

            for (int i = 0; i < MonsterGenerator.Instance._enemies.Count; i++)
            {
                if (col.gameObject == MonsterGenerator.Instance._enemies[i])
                {
                    MonsterGenerator.Instance._enemies.Remove(col.gameObject);
                }
            }
            AudioManager.instance.Explosion_();
            //GameObject explosion = Instantiate(Resources.Load("FlareMobile(" + colorCode + ")", typeof(GameObject))) as GameObject;
            //explosion.transform.position = transform.position;
            //Destroy(explosion, 2);
            Destroy(col.gameObject);
            Destroy(gameObject);
            GameManager.Instance.Score++;
        }


        //Hasnat's

        if (col.CompareTag("Asteroids"))
        {
            AudioManager.instance.Explosion_();
            string colorCode = col.GetComponent<FolowToCamera>().colorName;

            foreach (Transform item in col.transform)
            {
                if(item.name == "S_Ast")
                {
                    item.parent = null;
                    item.gameObject.SetActive(true);
                    item.GetComponent<Rigidbody>().AddExplosionForce(8f, col.transform.position, 50f);
                    MonsterGenerator.Instance._enemies.Add(item.gameObject);
                }
                else
                {
                    item.parent = null;
                    item.GetComponent<Rigidbody>().isKinematic = false;
                    item.GetComponent<Rigidbody>().AddExplosionForce(150f, col.transform.position, 50f);
                    Destroy(item.gameObject, 2f);
                }
            }
            GameObject explosion = Instantiate(Resources.Load("FlareMobile(" + colorCode + ")", typeof(GameObject))) as GameObject;
            explosion.transform.position = transform.position;
            Destroy(gameObject);
            Destroy(col.gameObject);
            Destroy(explosion, 2);
            MonsterGenerator.Instance._enemies.Remove(col.gameObject);
        }

        if(col.CompareTag("S_Ast"))
        {
            AudioManager.instance.Explosion_();
            string colorCode = col.GetComponent<FolowToCamera>().colorName;

            foreach (Transform item in col.transform)
            {
                item.parent = null;
                item.GetComponent<Rigidbody>().isKinematic = false;
                item.GetComponent<Rigidbody>().AddExplosionForce(150f, col.transform.position, 50f);
                Destroy(item.gameObject, 2f);
            }
            GameObject explosion = Instantiate(Resources.Load("FlareMobile(" + colorCode + ")", typeof(GameObject))) as GameObject;
            explosion.transform.position = transform.position;
            Destroy(col.gameObject);
            Destroy(explosion, 2);
            Destroy(gameObject);
            MonsterGenerator.Instance._enemies.Remove(col.gameObject);
            GameManager.Instance.Score++;
        }
    }

}

