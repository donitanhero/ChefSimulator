using Script.Data;
using Script.Global.Main.Launcher;
using Script.Module.GlassModule.GlassContainer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Module.Beverages
{
    public class BeveragesController
    {
        private BeveragesView _view;
        public void Constructor(BeveragesView View)
        {
            _view = View;
            _view.AddBeveragesButtonListener(BeveragesButtonClick);

            GlassContainer = MainLauncher.Instance.GlassContainer;
        }

        public GlassContainerController GlassContainer;

        public void BeveragesButtonClick()
        {
            MainLauncher.Instance.ButtonSound.Play();

            BeveragesData Beverages = new BeveragesData();
            Beverages.Base = "Teh";
            Beverages.Topping = "";
            Beverages.Picture = _view.BeveragesImage;
            _view.StartCooldown();
            GlassContainer.AssignGlassBase(Beverages);
        }
    }
}

