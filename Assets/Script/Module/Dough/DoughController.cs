using Script.Global.Main.Launcher;
using Script.Module.PanModule.PanContainer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Module.Dough
{
    public class DoughController
    {
        private DoughView _view;
        
        public void Constructor(DoughView View)
        {
            _view = View;

            PanContainer = MainLauncher.Instance.PanContainer;

            
            _view.AddDoughButtonListener(DoughClick);
        }

        public PanContainerController PanContainer;
        public void DoughClick()
        {
            MainLauncher.Instance.ButtonSound.Play();
            PanContainer.AssignPan("Martabak", _view.DoughFoodImage);
        }
    }
}

