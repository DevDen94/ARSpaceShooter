using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowToCamera : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.gameObject.transform.position);
        transform.Translate(Random.Range(0.5f,1.0f) * Time.deltaTime * Vector3.forward);


        transform.Rotate(0, 0, 0.05f);
    }

   
}
