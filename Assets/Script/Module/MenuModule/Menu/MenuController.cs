using Script.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Module.MenuModule.Menu
{
    public class MenuController
    {
        #region Constructor
        private MenuView _view;
        private MenuModel _model;
        public void Constructor(MenuView View)
        {
            _view = View;
            _model = new MenuModel();
            _model.SetView(_view);

            _view.InitiationRenderView(_model);
        }
        #endregion

        public void DestroyMenu()
        {
            _view.DestroyMenu();
        }


        public void SetType(string Type)
        {
            _model.SetMenuType(Type);
        }

        public void SetFood(FoodData Food)
        {
            _model.SetFood(Food);
        }

        public void SetBeverages(BeveragesData Beverages)
        {
            _model.SetBeverages(Beverages);
        }

        public FoodData GetFood()
        {
            return _model.GetFood();
        }

        public BeveragesData GetBeverages()
        {
            return _model.GetBeverages();
        }

        public string GetMenuType()
        {
            return _model.GetMenuType();
        }


    }
}

