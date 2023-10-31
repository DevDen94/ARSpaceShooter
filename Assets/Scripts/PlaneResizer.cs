using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneResizer : MonoBehaviour
{


    private Vector2 screenResolution;

    // Start is called before the first frame update
    void Start()
    {
        screenResolution = new Vector2(Screen.width, Screen.height);
        MatchPlaneToScreenSize();

        
    }


    private void Update()
    {
        if(screenResolution.x != Screen.width || screenResolution.y != Screen.height)
        {
            MatchPlaneToScreenSize();
            screenResolution.x = Screen.width;
            screenResolution.y = Screen.height;
        }

    }


    private void MatchPlaneToScreenSize()
    {
        float planeToCameraDistance = Vector3.Distance(gameObject.transform.position, Camera.main.transform.position);
        float planeHeightScale = (2.0f * Mathf.Tan(0.5f * Camera.main.fieldOfView * Mathf.Deg2Rad) * planeToCameraDistance) / 1.0f;
        float planeWifthScale = planeHeightScale * Camera.main.aspect;
        gameObject.transform.localScale = new Vector3(planeWifthScale, 1, planeHeightScale);

    }


}
