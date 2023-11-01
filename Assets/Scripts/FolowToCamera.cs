using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowToCamera : MonoBehaviour
{

    float x, y, z;


    private void Start()
    {
        int randomAxis = Random.Range(0, 3);

        // Set the rotationAxis based on the random choice
        switch (randomAxis)
        {
            case 0:
                x = 220f; // X-axis
                break;
            case 1:
                y = 220f; // Y-axis
                break;
            case 2:
                z = 220f; // Z-axis
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(Camera.main.gameObject.transform.position);
        transform.Translate(Random.Range(0.5f,1.0f) * Time.deltaTime * Vector3.forward);


        transform.Rotate(0, 0, 0.05f);
    }

   
}
