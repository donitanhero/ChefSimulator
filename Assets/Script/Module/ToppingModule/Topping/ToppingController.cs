using Script.Data;
using Script.Global.Main.Launcher;
using Script.Module.PlateModule.PlateContainer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Module.ToppingModule.Topping
{
    public class ToppingController
    {

        private ToppingModel _model;
        private ToppingView _view;

        public void Constructor(ToppingView View)
        {
            _view = View;
            _model = new ToppingModel();
            _model.SetView(_view);

            PlateContainer = MainLauncher.Instance.PlateContainer;
            _view.ToppingButtonAddListener(GiveTopping);
            _view.InitiationRenderView(_model);
        }

        public PlateContainerController PlateContainer;

        public void GiveTopping()
        {
            MainLauncher.Instance.ButtonSound.Play();
            PlateContainer.AssignPlateTopping(GetTopping(), _view.ToppingImage.sprite);
        }



        #region Set Method
        public void SetTopping(string Topping)
        {
            _model.SetTopping(Topping);
        }

        public void SetPicture(Image Img)
        {
            _model.SetPicture(Img);
        }

        #endregion
        #region Get Method

        public string GetTopping()
        {
            return _model.GetTopping();
        }

        public Image GetPicture()
        {
            return _model.GetPicture();
        }
        #endregion
    }
}

