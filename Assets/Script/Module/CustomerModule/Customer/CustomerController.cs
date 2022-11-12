using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Script.Data;
using UnityEngine.UI;
using Script.Module.MenuModule.MenuContainer;
using Script.Global.Main.Launcher;

namespace Script.Module.CustomerModule.Customer
{
    public class CustomerController
    {


        #region Constructor
        private CustomerView _view;
        private CustomerModel _model;
        public void Constructor(CustomerView View)
        {
            _view = View;
            _model = new CustomerModel();
            _model.SetView(_view);

            _view.InitiationRenderView(_model);
            _view.WaitingEnd += ServingNotComplete;

            MenuContainer = new MenuContainerController();
            MenuContainer.Constructor(_view.MenuContainer);
            Manager = MainLauncher.Instance.Manager;
        }
        #endregion
        public MenuContainerController MenuContainer;
        public GameManager Manager;

        public void StartWaiting(float Time)
        {
            _view.StartWaiting(Time);
        }

        public bool CheckAccomplishment()
        {
            var FoodList = GetAllFood();
            var BeveragesList = GetAllBeverages();

            foreach(FoodData order in FoodList)
            {
                if (order.Done == false){
                    return false;
                }
            }

            foreach(BeveragesData order in BeveragesList)
            {
                if (order.Done == false)
                {
                    return false;
                }
            }
            return true;
        }

        public void ServingComplete()
        {
            //scoring

            Manager.IncrementCustomerServed();
            DestroyCustomer();
            
        }

        public void ServingNotComplete()
        {
            DestroyCustomer();
            Debug.Log("Customer Not Served, serve them well");
        }

        public bool FoodServing(FoodData Food)
        {
            var ListFoodOrder = GetAllFood();
            foreach (FoodData order in ListFoodOrder)
            {
                if (Food.Base == order.Base && Food.Topping == order.Topping && order.Done == false)
                {
                    SetFoodDoneByID(order.ID);
                    MenuContainer.RemoveFoodMenu(order);
                    return true;
                }
            }
            return false;
            
        }

        public bool BevaragesServing(BeveragesData Beverage)
        {
            var ListBeverageOrder = GetAllBeverages();
            foreach(BeveragesData order in ListBeverageOrder)
            {
                
                if(Beverage.Base == order.Base && Beverage.Topping == order.Topping && order.Done == false)
                {
                    
                    SetBeveragesDoneByID(order.ID);
                    MenuContainer.RemoveBeveragesMenu(order);
                    return true;
                }
            }
            return false;
        }

        public void DestroyCustomer()
        {
            _view.CustomerDestroy();
        }


        public void SetFoodOrder(FoodData Food)
        {
            MenuContainer.CreateFoodMenu(Food);
            _model.AddFood(Food);
        }

        public void SetBeveragesOrder(BeveragesData Beverages)
        {
            MenuContainer.CreateBeveragesMenu(Beverages);
            _model.AddBeverages(Beverages);
        }

        public void SetCustomerImage(Sprite img)
        {
            _model.SetCustomerImage(img);
        }

        public void SetFoodDoneByID(string ID)
        {
            _model.SetFoodDone(ID);
        }

        public void SetBeveragesDoneByID(string ID)
        {
            _model.SetBeveragesDone(ID);
        }

        public void SetCustomerID(string ID)
        {
            _model.SetID(ID);
        }

        public List<FoodData> GetAllFood()
        {
            return _model.GetAllFood();
        }

        public List<BeveragesData> GetAllBeverages()
        {
            return _model.GetAllBeverages();
        }

        public string GetID()
        {
            return _model.GetID();
        }
        
        


    }
}

