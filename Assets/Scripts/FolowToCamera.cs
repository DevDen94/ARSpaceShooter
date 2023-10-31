using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowToCamera : MonoBehaviour
{
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.gameObject.transform.position);
        transform.Translate(Vector3.forward * Random.Range(1.0f,2.0f) * Time.deltaTime);
    }

   
}
