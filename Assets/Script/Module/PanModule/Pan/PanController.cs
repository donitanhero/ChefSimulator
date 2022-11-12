using Script.Data;
using Script.Global.Main.Launcher;
using Script.Module.PlateModule.PlateContainer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Module.PanModule.Pan
{
    public class PanController
    {

        private PanView _view;
        private PanModel _model;
        public void Constructor(PanView View)
        {
            _view = View;
            _model = new PanModel();
            _model.SetView(_view);

            _view.InitiationRenderView(_model);
            _view.CookingDone += CookingDone;
            _view.OverCookingDone += OverCookingDone;
            _view.PanButtonAddListener(CheckFood);

            PlateContainer = MainLauncher.Instance.PlateContainer;
        }

        private PlateContainerController PlateContainer;

        public void CookingDone()
        {
            SetSuccess(true);
            
        }

        public void OverCookingDone()
        {
            SetOverCook(true);
        }

        public void CheckFood()
        {
            MainLauncher.Instance.ButtonSound.Play();
            if (GetCooking() && GetOverCook())
            {
                RemoveFood();
                
            }
            else if(GetCooking() && GetSuccess())
            {
                SendFoodToPlate();
            }
        }

        public void CookFood(string Base, Sprite Image)
        {
            SetCooking(true);
            SetBase(Base);
            SetImage(Image);
        }

        public bool CheckPanEmpty()
        {
            if (GetCooking())
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public void SendFoodToPlate()
        {
            FoodData Food = new FoodData();
            Food.Base = GetBase();
            Food.Topping = "";
            Food.Picture = GetImage();
            //sending
            PlateContainer.AssignPlateBase(Food);

            ResetPan();
        }

        public void RemoveFood()
        {
            //throwing
            Debug.Log("unsuccess");
            ResetPan();
        }

        public void ResetPan()
        {
            SetCooking(false);
            SetBase("");
            SetSuccess(false);
            SetOverCook(false);

            _view.Timer = 0;
            _view.TimerAction = null;
        }

        #region Set Method

        public void SetCooking(bool Cook)
        {
            _model.SetCooking(Cook);
        }

        public void SetOverCook(bool OverCook)
        {
            _model.SetOverCook(OverCook);
        }

        public void SetBase(string FoodBase)
        {
            _model.SetBase(FoodBase);
        }

        public void SetCookDuration(int Duration)
        {
            _model.SetCookDuration(Duration);
        }

        public void SetOverCookDuration(int Duration)
        {
            _model.SetOverCookDuration(Duration);
        }
        public void SetSuccess(bool PanSuccess)
        {
            _model.SetSuccess(PanSuccess);
        }

        public void SetID(string id)
        {
            _model.SetID(id);
        }

        public void SetImage(Sprite Image)
        {
            _model.SetImage(Image);
        }

        #endregion

        #region Get Method

        public bool GetCooking()
        {
            return _model.GetCooking();
        }

        public string GetBase()
        {
            return _model.GetBase();
        }

        public int GetCookDuration()
        {
            return _model.GetCookDuration();
        }

        public int GetOverCookDuration()
        {
            return _model.GetOverCookDuration();
        }

        public bool GetSuccess()
        {
            return _model.GetSuccess();
        }

        public string GetID()
        {
            return _model.GetID();
        }

        public bool GetOverCook()
        {
            return _model.GetOverCook();
        }

        public Sprite GetImage()
        {
            return _model.GetImage();
        }

        #endregion
    }
}

