using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebCamScript : MonoBehaviour {
    public GameObject webCameraPlane;
    public Button fire;
    public ExtendedFlycam EFC; // For editor use only

    // Use this for initialization
    void Start () {
        if(Application.isMobilePlatform) {
            GameObject cameraParent = new GameObject("camParent");
            cameraParent.transform.position = this.transform.position;
            this.transform.parent = cameraParent.transform;
            cameraParent.transform.Rotate(Vector3.right, 90);
            Input.gyro.enabled = true;
        }
        else if (Application.isEditor)
        {
            EFC.enabled = true;
        }


        //fire.onClick.AddListener(OnButtonDown);

       
        WebCamTexture webCameraTexture = new WebCamTexture();
        webCameraPlane.GetComponent<MeshRenderer>().material.mainTexture = webCameraTexture;
        webCameraTexture.Play();

        
        


        

    }
	
	// Update is called once per frame
	void Update () {
        if (Application.isMobilePlatform)
        {
            Quaternion cameraRotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
            this.transform.localRotation = cameraRotation;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            BulletFireButton();
        }

    }

    public void BulletFireButton()
    {

       GameObject bullet = Instantiate(Resources.Load("bullet", typeof(GameObject))) as GameObject;
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        bullet.transform.rotation = Camera.main.transform.rotation;
        bullet.transform.position = Camera.main.transform.position;
        rb.AddForce(Camera.main.transform.forward * 800f);
        Destroy(bullet, 3);

        if (AudioManager.instance.sound)
            GetComponent<AudioSource>().Play();


    }

}
