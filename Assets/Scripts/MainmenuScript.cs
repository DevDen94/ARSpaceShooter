using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainmenuScript : MonoBehaviour
{


    [SerializeField] GameObject MainMenuPanel;
    [SerializeField] GameObject MonsterSelectPanel;
    [SerializeField] GameObject SettingsSelectPanel;
    [SerializeField] GameObject LoadingPanel;
    [SerializeField] Text CandiesText,CandiesText2;
    
    public bool Sound;
    
    public bool Music;

    public int Candies;

    public Toggle Music_, Sound_;




    // Start is called before the first frame update
    void Start()
    {

        if(AudioManager.instance.music == true)
        {
            Music_.isOn = true;
        }
        else
        {
            Music_.isOn = false;
        }

        if (AudioManager.instance.sound == true)
        {
            Sound_.isOn = true;
        }
        else if (AudioManager.instance.sound == false)
        {
            Sound_.isOn = false;
        }

        //PlayerPrefs.SetInt("TotalScore", 50);
        Time.timeScale = 1;
        CandiesText.text = ""+PlayerPrefs.GetInt("TotalScore",0);
        CandiesText2.text = "" + PlayerPrefs.GetInt("TotalScore", 0);
    }

    public void PlayButton()
    {
        AudioManager.instance.onButtonClick();
        SceneManager.LoadScene("GamePlay");
    }


    public void MainMenuPanelButton()
    {
        AudioManager.instance.onButtonClick();

        MainMenuPanel.SetActive(true);
        MonsterSelectPanel.SetActive(false);
        SettingsSelectPanel.SetActive(false);
    }


    public void MonsterSelectPanelButton()
    {
        AudioManager.instance.onButtonClick();

        MainMenuPanel.SetActive(false);
        MonsterSelectPanel.SetActive(true);
        SettingsSelectPanel.SetActive(false);
    }

    public void SettingsPanelButton()
    {
        AudioManager.instance.onButtonClick();

        MainMenuPanel.SetActive(false);
        MonsterSelectPanel.SetActive(false);
        SettingsSelectPanel.SetActive(true);

    }
    public void click()
    {
        AudioManager.instance.onButtonClick();

    }

    public void quit()
    {
        Application.Quit();
    }


    public void MusicToogle()
    {
        if (Music_.isOn)
        {
            AudioManager.instance.music = true;
            AudioManager.instance.MainMenu.Play();
        }
        else if (!Music_.isOn)
        {
            AudioManager.instance.music = false;
            AudioManager.instance.MainMenu.Stop();
        }

    }
    public void soundToogle()
    {
        if (Sound_.isOn)
        {
            Debug.Log("yep sound on");
            AudioManager.instance.sound = true;
        }
        else if (!Sound_.isOn)
        {
            Debug.Log("Not sound on");
            AudioManager.instance.sound = false;
        }
    }

}
