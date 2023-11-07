using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    [SerializeField] GameObject PausePanel;
    [SerializeField] GameObject GameplayPanel;
    [SerializeField] GameObject GameoverPanel;
    [SerializeField] Text ScoreText;
    [SerializeField] Text TotalScoreText;
    [SerializeField] Text LivesText;
    [SerializeField] Image HealthBar;
    [SerializeField] GameObject CrossHairKillEffect;
    public GameObject ScreenDamageEffect;
    [SerializeField] GameObject MonsterGenerator;
    public int Score;
    public int TotalScore;
    public int Lives;
    public int maxHealth = 100;
    public float currentHealth;

    int pre_score,pre_lives;
    public bool isover;

    public int Coins;

    // Start is called before the first frame update
    void Start()
    {
        TotalScore = PlayerPrefs.GetInt("TotalScore", 0);

        isover = false;
        Instance = this;
        Time.timeScale = 1;
        StartCoroutine(UIWork());
        pre_score = 0;
        Score = 0;
        pre_lives = Lives;
        Lives = 5;

        currentHealth = maxHealth / 100;
    }

    
    
    private IEnumerator UIWork()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(0.15f);
            ScoreText.text = "" + Score;
            LivesText.text = "" + Lives;
            HealthBar.fillAmount = currentHealth;
            
            if(pre_score != Score)
            {
                //Show kill effect
                pre_score = Score;

                CrossHairKillEffect.SetActive(true);
                Invoke("DisableKillEffect", 0.1f);
                Debug.Log("Score");
            }

            if(pre_lives != Lives)
            {
                //Show damage taken effect
                pre_lives = Lives;
                ScreenDamageEffect.SetActive(true);
                Invoke("DisableDamageTakenEffect", 0.1f);
                Debug.Log("Score");
            }


            if (Lives <= 0 && !isover)
            {
                MonsterGenerator.SetActive(false);
                ShowGameOverPanel();
                Destroy(GameObject.FindWithTag("Enemy"));
                
                PlayerPrefs.SetInt("TotalScore",TotalScore + Score);
                TotalScore = TotalScore +Score;
                TotalScoreText.text = "" + Score;
                Debug.Log("Score");
                isover = true;
                GoogleAdMobController.instance.ShowInterstitialAd();
            }

            if(currentHealth <= 0)
            {
                MonsterGenerator.SetActive(false);
                ShowGameOverPanel();
                Destroy(GameObject.FindWithTag("Enemy"));

                PlayerPrefs.SetInt("TotalScore", TotalScore + Score);
                TotalScore = TotalScore + Score;
                TotalScoreText.text = "" + Score;
                Debug.Log("Score");
                isover = true;
                GoogleAdMobController.instance.ShowInterstitialAd();

                yield break;
            }
        }
    }


    private void DisableKillEffect()
    {

        CrossHairKillEffect.SetActive(false);
    }

    public void DisableDamageTakenEffect()
    {

        ScreenDamageEffect.SetActive(false);
    }


    public void PauseButton()
    {
        Time.timeScale = 0;
        AudioManager.instance.onButtonClick();

        PausePanel.SetActive(true);
        GameplayPanel.SetActive(false);
        



    }


    public void ResumeButton()
    {
        Time.timeScale = 1;
        AudioManager.instance.onButtonClick();

        PausePanel.SetActive(false);
        GameplayPanel.SetActive(true);
        

    }


    public void RestartButton()
    {
        AudioManager.instance.onButtonClick();

        SceneManager.LoadScene("GamePlay");

    }


    public void SettingsButton()
    {
        PausePanel.SetActive(false);
        GameplayPanel.SetActive(false);
        AudioManager.instance.onButtonClick();



    }


    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
        AudioManager.instance.onButtonClick();

    }

    public void ShowGameOverPanel()
    {

        AudioManager.instance.fail_();

        PausePanel.SetActive(false);
        GameplayPanel.SetActive(false);
        GameoverPanel.SetActive(true);

    }

}
