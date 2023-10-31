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
            Destroy(other.gameObject);
            GameManager.Instance.Lives--;
        }
    }
}
