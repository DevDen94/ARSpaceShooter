using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public AudioSource MainMenu, ButtonClick, fail;

    public bool sound;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
       
    }
    private void Start()
    {
        sound = true;
    }

    public void onButtonClick()
    {

        if(sound)
        ButtonClick.Play();
    }
    public void fail_()
    {
        if(sound)
        fail.Play();
    }

}
