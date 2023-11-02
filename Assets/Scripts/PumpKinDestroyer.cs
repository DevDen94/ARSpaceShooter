using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpKinDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            for (int i = 0; i < MonsterGenerator.Instance._enemies.Count; i++)
            {
                if (other.gameObject == MonsterGenerator.Instance._enemies[i])
                {
                    MonsterGenerator.Instance._enemies.Remove(other.gameObject);
                }
                else
                {
                    Debug.Log("No it is not in the List");
                }
            }

            Destroy(other.gameObject);
            GameManager.Instance.Lives--;
        }
        if(other.CompareTag("Asteroids"))
        {
            for (int i = 0; i < MonsterGenerator.Instance._enemies.Count; i++)
            {
                if (other.gameObject == MonsterGenerator.Instance._enemies[i])
                {
                    MonsterGenerator.Instance._enemies.Remove(other.gameObject);
                }
                else
                {
                    Debug.Log("No it is not in the List");
                }
            }

            Destroy(other.gameObject);
            GameManager.Instance.Lives--;
        }
    }
}
