using Script.Global.Main.Launcher;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    public Button[] StageButton;
    private int PlayingLevelIndex;
    private List<int> LevelPart = new List<int>();
    private bool[] LevelUnlockStatus = { true, false };

    //current level attribute to be accessed from other scene
    public float TimeLimit;
    public int ServedCustomer;
    public Action<float, int> WinConditionFunc;
    public Action InitiationLevelFunction;

    


    public static LevelManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void Initiation()
    {
        for (int i = 0; i < StageButton.Length; i++)
        {
            LevelPart.Add(0);

        }


        StageButton[0].onClick.AddListener(Stage1ButtonFunction);
        StageButton[0].interactable = LevelUnlockStatus[0];
        if(LevelPart[0] == 3)
        {
            StageButton[0].interactable = false;
        }


        StageButton[1].onClick.AddListener(Stage2ButtonFunction);
        StageButton[1].interactable = LevelUnlockStatus[1];
        if (LevelPart[1] == 3)
        {
            StageButton[1].interactable = false;
        }


        
    }

    public void Stage1ButtonFunction()
    {
        switch (LevelPart[0])
        {
            case 2:
                Debug.Log("1.3 Complete");
                NextPartInLevelCheck();
                StageButton[0].interactable = false;
                break;
            case 1:
                Debug.Log("1.2 Complete");
                NextPartInLevelCheck();
                break;
            case 0:
                InitiationLevelFunction = null;
                InitiationLevelFunction += Stage1ButtonFunction;
                
                //level 1.1 Gameplay
                TimeLimit = 90;
                ServedCustomer = 10;
                WinConditionFunc = null;
                WinConditionFunc += WinCondition11;
                SceneManager.LoadScene("PlayScene");
                
                PlayingLevelIndex = 0;
                break;
            default:
                Debug.Log(LevelPart[0]);
                Debug.Log("Undefined");
                break;

        }
    }

    public void Stage2ButtonFunction()
    {
        switch (LevelPart[1])
        {
            case 2:
                Debug.Log("2.3 Complete");
                NextPartInLevelCheck();
                StageButton[1].interactable = false;
                break;
            case 1:
                Debug.Log("2.2 Complete");
                NextPartInLevelCheck();
                break;
            case 0:
                InitiationLevelFunction = null;
                InitiationLevelFunction += Stage2ButtonFunction;

                //level 1.1 Gameplay
                TimeLimit = 90;
                ServedCustomer = 9;
                WinConditionFunc = null;
                WinConditionFunc += WinCondition21;
                SceneManager.LoadScene("PlayScene");

                PlayingLevelIndex = 1;
                break;
            default:
                Debug.Log(LevelPart[1]);
                Debug.Log("Undefined");
                break;

        }
    }

    public void WinCondition11(float TimeLimit, int Customer)
    {
        //example neeed 5 customer
        if (TimeLimit < 0 && Customer < ServedCustomer)
        {
            Time.timeScale = 0;
            MainLauncher.Instance.Manager.Lose();  
        }
        else if (TimeLimit < 0 && Customer >= ServedCustomer)
        {
            Time.timeScale = 0;
            MainLauncher.Instance.Manager.Win();
            LevelUnlockStatus[PlayingLevelIndex + 1] = true;
            NextPartInLevelCheck();
        }
    }

    public void WinCondition21(float TimeLimit, int Customer)
    {
        //example neeed 5 customer
        if (TimeLimit < 0 && Customer < ServedCustomer)
        {
            Debug.Log("You Lose");
            Time.timeScale = 0;
            MainLauncher.Instance.Manager.Lose();
        }
        else if (Customer >= ServedCustomer)
        {

            Debug.Log("You Win");
            Time.timeScale = 0;
            MainLauncher.Instance.Manager.Win();
            //LevelUnlockStatus[PlayingLevelIndex + 1] = true;
            NextPartInLevelCheck();
        }
    }

    public void NextPartInLevelCheck()
    {
        if(LevelPart[PlayingLevelIndex] < 3)
        {
            LevelPart[PlayingLevelIndex] += 1;
        }
    }
}
