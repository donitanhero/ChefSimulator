using Script.Data;
using Script.Global.Main.Launcher;
using Script.Module.CustomerModule.CustomerContainer;
using Script.Module.PlateModule.PlateContainer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Module.PlateModule.Plate
{
    public class PlateController
    {
        #region Constructor
        private PlateView _view;
        private PlateModel _model;

        public void Constructor(PlateView View)
        {
            _view = View;
            _model = new PlateModel();
            _model.SetView(_view);

            _view.InitiationRenderView(_model);
            _view.AddPlateButtonListener(SendFoodToCustomer);

            CustomerContainer = MainLauncher.Instance.CustomerContainer;
            Initiation();
        }
        #endregion

        public CustomerContainerController CustomerContainer;

        public void Initiation()
        {

        }

        public void AddTopping(string Topping, Sprite Image)
        {
            FoodData Food = GetFood();
            Food.Topping = Topping;
            Food.ToppingPicture = Image;
            SetFood(Food);
        }

        public bool CheckPlateEmpty()
        {
            if (GetFood().Base == "" || GetFood().Base == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckToppingEmpty()
        {
            if (GetFood().Topping == "" || GetFood().Topping == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SendFoodToCustomer()
        {
            MainLauncher.Instance.ButtonSound.Play();
            if (CustomerContainer.FoodAccopmlishment(GetFood()))
            {
                ResetPlate();
            }
            
        }

        public void ResetPlate()
        {
            FoodData Food = _model.GetFood();
            Food.Base = "";
            Food.Topping = "";
            Food.Picture = null;
            SetFood(Food);
        }

        public void SetFood(FoodData Food)
        {
            _model.SetFood(Food);
        }

        



        public FoodData GetFood()
        {
            return _model.GetFood();
        }
    }
}

