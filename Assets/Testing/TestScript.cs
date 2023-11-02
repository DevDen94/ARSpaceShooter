using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TestScript : MonoBehaviour
{

    float val;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        val += Time.fixedDeltaTime;

        Debug.Log(val);
    }
}
