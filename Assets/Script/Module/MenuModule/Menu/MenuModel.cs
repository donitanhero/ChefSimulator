using Script.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Module.MenuModule.Menu
{
    public interface IMenuModel
    {
        FoodData Food { get; }
        BeveragesData Beverages { get; }
        string Type { get; }
    }

    public class MenuModel : IMenuModel
    {
        #region Constructor
        private MenuView _view;
        public void SetView(MenuView View)
        {
            _view = View;
        }
        private void SetDataAsDirty()
        {
            _view.UpdateRenderView(this);
        }
        #endregion

        private FoodData _food;
        private BeveragesData _beverages;
        private string _type;

        public void SetFood(FoodData food)
        {
            _food = food;
            SetDataAsDirty();
        }

        public void SetBeverages(BeveragesData beverages)
        {
            _beverages = beverages;
            SetDataAsDirty();
        }

        public void SetMenuType(string type)
        {
            _type = type;
            SetDataAsDirty();
        }


        public string GetMenuType()
        {
            return _type;
        }

        public FoodData GetFood()
        {
            return _food;
        }

        public BeveragesData GetBeverages()
        {
            return _beverages;
        }

        public FoodData Food
        {
            get
            {
                return _food;
            }
        }

        public BeveragesData Beverages
        {
            get
            {
                return _beverages;
            }
        }

        public string Type
        {
            get
            {
                return _type;
            }
        }
    }
}


