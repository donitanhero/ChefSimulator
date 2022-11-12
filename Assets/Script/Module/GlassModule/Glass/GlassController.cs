using Script.Data;
using Script.Global.Main.Launcher;
using Script.Module.CustomerModule.CustomerContainer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Module.GlassModule.Glass
{
    public class GlassController
    {
        #region Constructor
        private GlassView _view;
        private GlassModel _model;
        public void Constructor(GlassView View)
        {
            _view = View;
            _model = new GlassModel();
            _model.SetView(_view);

            _view.InitiationRenderView(_model);
            _view.AddGlassButtonListener(SendBeveragesToCustomer);
            CustomerContainer = MainLauncher.Instance.CustomerContainer;
        }
        #endregion

        public CustomerContainerController CustomerContainer;

        public bool CheckGlassEmpty()
        {
            if (GetBeverages().Base == "" || GetBeverages().Base == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SendBeveragesToCustomer()
        {
            MainLauncher.Instance.ButtonSound.Play();
            if (CustomerContainer.BeveragesAccomplishment(GetBeverages()))
            {
                ResetGlass();
            }

        }

        public void ResetGlass()
        {
            BeveragesData Beverages = _model.GetBeverages();
            Beverages.Base = "";
            Beverages.Topping = "";
            Beverages.Picture = null;
            SetBeverages(Beverages);
        }

        public void SetBeverages(BeveragesData Beverages)
        {
            _model.SetBeverages(Beverages);
            
        }

        public BeveragesData GetBeverages()
        {
            return _model.GetBeverages();
        }

    }
}

