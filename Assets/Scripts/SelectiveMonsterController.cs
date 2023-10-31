using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectiveMonsterController : MonoBehaviour
{

    public GameObject PumpkinGenerator;
    public GameObject BatsGenerator;
    public GameObject GhostGenerator;
    public GameObject WitchGenerator;

    public int MonsterTypeCheck;

    // Start is called before the first frame update
    void Start()
    {
        MonsterTypeCheck = 0;
        MonsterTypeCheck = PlayerPrefs.GetInt("MonsterSelect", 0);

        PumpkinGenerator.SetActive(false);
        BatsGenerator.SetActive(false);
        GhostGenerator.SetActive(false);
        WitchGenerator.SetActive(false);
        SetMonsterGenerator();


    }

    public void SetMonsterGenerator()
    {
        if(MonsterTypeCheck == 0)
        {
            PumpkinGenerator.SetActive(true);
            BatsGenerator.SetActive(false);
            GhostGenerator.SetActive(false);
            WitchGenerator.SetActive(false);

        }
        else if(MonsterTypeCheck == 1)
        {
            PumpkinGenerator.SetActive(false);
            BatsGenerator.SetActive(true);
            GhostGenerator.SetActive(false);
            WitchGenerator.SetActive(false);

        }
        else if(MonsterTypeCheck == 2)
        {
            PumpkinGenerator.SetActive(false);
            BatsGenerator.SetActive(false);
            GhostGenerator.SetActive(true);
            WitchGenerator.SetActive(false);

        }
        else if(MonsterTypeCheck == 3)
        {
            PumpkinGenerator.SetActive(false);
            BatsGenerator.SetActive(false);
            GhostGenerator.SetActive(false);
            WitchGenerator.SetActive(true);

        }





    }
}
