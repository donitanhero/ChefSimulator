using Script.Data;
using Script.Module.MenuModule.Menu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Module.MenuModule.MenuContainer
{
    public class MenuContainerController
    {
        #region Constuctor
        private MenuContainerView _view;
        private MenuContainerModel _model;
        public void Constructor(MenuContainerView View)
        {
            _view = View;
            _model = new MenuContainerModel();
            _model.SetView(_view);

            _view.InitiationRenderView(_model);
        }
        #endregion

        public void CreateFoodMenu(FoodData Food)
        {
            MenuController Menu = new MenuController();
            Menu.Constructor(_view.InstantiateFood());
            Menu.SetFood(Food);
            Menu.SetType("Food");
            AddMenu(Menu);
        }

        public void CreateBeveragesMenu(BeveragesData Beverages)
        {
            MenuController Menu = new MenuController();
            Menu.Constructor(_view.InstantiateBeverages());
            Menu.SetBeverages(Beverages);
            Menu.SetType("Beverages");
            AddMenu(Menu);
        }

        public void RemoveFoodMenu(FoodData Food)
        {
            List<MenuController> MenuList = GetAllMenu();
            foreach(MenuController Menu in MenuList)
            {
                if(Menu.GetFood() == Food)
                {

                    Menu.DestroyMenu();
                    RemoveMenu(Menu);
                    break;
                }
            }
        }

        public void RemoveBeveragesMenu(BeveragesData Beverages)
        {
            List<MenuController> MenuList = GetAllMenu();
            foreach (MenuController Menu in MenuList)
            {
                if (Menu.GetBeverages() == Beverages)
                {

                    Menu.DestroyMenu();
                    RemoveMenu(Menu);
                    break;
                }
            }
        }

        public void AddMenu(MenuController Menu)
        {
            _model.AddMenu(Menu);
        }

        public List<MenuController> GetAllMenu()
        {
            return _model.GetAllMenu();
        }

        public void RemoveMenu(MenuController Menu)
        {
            _model.RemoveMenu(Menu);
        }
        
    }
}

