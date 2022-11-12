using Script.Global.Main.Launcher;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Action<float,int> WinLoseConditionFunc;
    public float TimeLimit;
    public int ServedCustomer;

    public Text TimeLimitText;
    public Text ServedCustomerText;

    public GameObject EndGameUI;
    public Text GameResultText;
    public Button QuitButton;
    public Button RestartButton;

    private void Start()
    {
        QuitButton.onClick.RemoveAllListeners();
        QuitButton.onClick.AddListener(QuitFunction);

        RestartButton.onClick.RemoveAllListeners();
        RestartButton.onClick.AddListener(RestartFunction);
    }

    void Update()
    {
        if(WinLoseConditionFunc != null)
        {
            if(TimeLimit >0)
            {

                TimeLimit -= Time.deltaTime;
                TimeLimitText.text = ConvertSecondsToMinute(TimeLimit);
            }
            else
            {
                WinLoseConditionFunc.Invoke(TimeLimit, ServedCustomer);
                WinLoseConditionFunc = null;
                TimeLimitText.text = ConvertSecondsToMinute(TimeLimit);
            }
        }
    }

    public void IncrementCustomerServed()
    {
        ServedCustomer += 1;
        ServedCustomerText.text = ServedCustomer.ToString();
        WinLoseConditionFunc.Invoke(TimeLimit, ServedCustomer);
    }

    public string ConvertSecondsToMinute(float RawSeconds)
    {
        float Minute = math.floor(RawSeconds / 60) ;
        float Seconds = math.floor(RawSeconds - 60 * Minute);

        return Minute.ToString() + " : " + Seconds.ToString();

        
    }

    public void Win()
    {
        EndGameUI.gameObject.SetActive(true);
        GameResultText.text = "You Win";
    }

    public void Lose()
    {
        EndGameUI.gameObject.SetActive(true);
        GameResultText.text = "You Lose";
        RestartButton.gameObject.SetActive(true); 
    }

    public void RestartFunction()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitFunction()
    {
        SceneManager.LoadScene("LevelScene");
    }

}
