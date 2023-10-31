using UnityEngine;
using System.Collections;

public class collisionScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
            GameObject explosion = Instantiate(Resources.Load("FlareMobile", typeof(GameObject))) as GameObject;
            explosion.transform.position = transform.position;
            Destroy(col.gameObject);
            Destroy(explosion, 2);
            Destroy(gameObject);
            GameManager.Instance.Score++;
        }


    }

}

