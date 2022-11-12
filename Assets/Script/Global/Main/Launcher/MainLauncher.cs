using Script.Global.ID;
using Script.Global.Main.View;
using Script.Module.Beverages;
using Script.Module.CustomerModule.Customer;
using Script.Module.CustomerModule.CustomerContainer;
using Script.Module.Dough;
using Script.Module.GlassModule.GlassContainer;
using Script.Module.PanModule.PanContainer;
using Script.Module.PlateModule.PlateContainer;
using Script.Module.ToppingModule.ToppingContainer;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Global.Main.Launcher
{
    public class MainLauncher : MonoBehaviour
    {
        private MainView _view;

        [SerializeField]
        public int angka = 10;

        public static MainLauncher Instance { get; private set; }
        
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

        private void Start()
        {
           
        }

        public static MainLauncher GetInstance()
        {
            return Instance;
        }

        public void SetView(MainView View)
        {
            _view = View;
        }

        //Dependency List
        public CustomerContainerController CustomerContainer = new CustomerContainerController();
        public IDGenerator IDMaker = new IDGenerator();
        public PanContainerController PanContainer = new PanContainerController();
        public DoughController Dough = new DoughController();
        public ToppingContainerController ToppingContainer = new ToppingContainerController();
        public PlateContainerController PlateContainer = new PlateContainerController();
        public GlassContainerController GlassContainer = new GlassContainerController();
        public BeveragesController Beverages = new BeveragesController();
        public GameManager Manager;


        public Action<float, int> WinLoseFunc;
        public AudioSource ButtonSound;
        public AudioSource BGSound;
        

        public void Initiation()
        {
            BGSound = _view.BGAudio;
            ButtonSound = _view.ButtonAudio;

            BGSound.Play();

            CustomerContainer.Constructor(_view.CustomerContainer);
            PanContainer.Constructor(_view.PanContainer);
            Dough.Constructor(_view.Dough);
            ToppingContainer.Constructor(_view.ToppingContainer);
            PlateContainer.Constructor(_view.PlateContainer);
            GlassContainer.Constructor(_view.GlassContainer);
            Beverages.Constructor(_view.Beverages);
            Manager.TimeLimit = LevelManager.Instance.TimeLimit;
            Manager.WinLoseConditionFunc = LevelManager.Instance.WinConditionFunc;
        }

        

        
        
    }
}

