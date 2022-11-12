using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLauncher : MonoBehaviour
{
    public Button[] StageButton;
    // Start is called before the first frame update
    void Start()
    {
        LevelManager.Instance.StageButton = StageButton;
        LevelManager.Instance.Initiation();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
