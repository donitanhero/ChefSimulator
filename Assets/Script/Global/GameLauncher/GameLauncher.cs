using Script.Global.Main.Launcher;
using Script.Global.Main.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLauncher : MonoBehaviour
{
    public MainView View;
    public GameManager Manager;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        MainLauncher.Instance.Manager = Manager;
        MainLauncher.Instance.SetView(View);

        MainLauncher.Instance.Initiation();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
