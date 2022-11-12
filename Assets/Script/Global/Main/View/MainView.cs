using Script.Module.Beverages;
using Script.Module.CustomerModule.CustomerContainer;
using Script.Module.Dough;
using Script.Module.GlassModule.GlassContainer;
using Script.Module.PanModule.PanContainer;
using Script.Module.PlateModule.PlateContainer;
using Script.Module.ToppingModule.ToppingContainer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Script.Global.Main.View
{
    public class MainView: MonoBehaviour
    {
        public CustomerContainerView CustomerContainer;
        public PanContainerView PanContainer;
        public DoughView Dough;
        public ToppingContainerView ToppingContainer;
        public PlateContainerView PlateContainer;
        public GlassContainerView GlassContainer;
        public BeveragesView Beverages;
        public AudioSource BGAudio;
        public AudioSource ButtonAudio;

    }
}

