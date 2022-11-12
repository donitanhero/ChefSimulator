using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Script.Module.CustomerModule.Customer;
using Script.Data;
using Script.Global.ID;
using Script.Global.Main.Launcher;

namespace Script.Module.CustomerModule.CustomerContainer
{
    public class CustomerContainerController
    {

        #region Constructor
        private CustomerContainerView _view;
        private CustomerContainerModel _model;
        public MainLauncher Launcher;

        public void Constructor(CustomerContainerView View)
        {
            _view = View;
            _model = new CustomerContainerModel();
            _model.SetView(_view);


            _view.CreateCustomer += CreateCustomer;
            _view.InitiationRenderView(_model);

            
            IDMaker = MainLauncher.Instance.IDMaker;
            //Initiation();
        }

        #endregion

        public int MaximumOrder = 3;

        public string[] FoodBase = new string[] {"Martabak"};
        public string[] FoodTopping = new string[] { "Cokelat",""};

        public string[] BeveragesBase = new string[] { "Teh" };
        public string[] BeveragesTopping = new string[] { "" };

        public string[] Menu = new string[] { "Food", "Beverages" };

        
        public IDGenerator IDMaker;

        public bool Stop;
        public float SpawnCooldown;
        
        public void Initiation()
        {
            
            
        }

        public void CreateCustomer()
        {
            CustomerController NewCustomer = new CustomerController();
            NewCustomer.Constructor(_view.Instantiate());
            NewCustomer.SetCustomerID(IDMaker.GenerateID());
            for (int i=0; i< Random.Range(1, MaximumOrder + 1); i++)
            {
                string MenuChoice = Menu[Random.Range(0, Menu.Length)];
                if (MenuChoice == "Food")
                {
                    NewCustomer.SetFoodOrder(GenerateFood());
                    
                }
                else if(MenuChoice == "Beverages")
                {
                    NewCustomer.SetBeveragesOrder(GenerateBeverages());
                   
                }
            }
            NewCustomer.SetCustomerImage(_view.CustomerPicture[Random.Range(0,_view.CustomerPicture.Length)]);
            NewCustomer.StartWaiting(20);
            _model.AddCustomerData(NewCustomer);
        }

        public FoodData GenerateFood()
        {

            FoodData Food = new FoodData();
            var BaseIndex = Random.Range(0, FoodBase.Length);
            Food.Base = FoodBase[BaseIndex];
            Food.Picture = _view.FoodBaseList[BaseIndex];

            var ToppingIndex = Random.Range(0, FoodTopping.Length);
            Food.Topping = FoodTopping[ToppingIndex];
            Food.ID = IDMaker.GenerateID();

            if (Food.Topping != " ")
            {
                Food.ToppingPicture = _view.FoodToppingList[ToppingIndex];
            }
            

            return Food;
        }

        public BeveragesData GenerateBeverages()
        {
            BeveragesData Beverages = new BeveragesData();
            var BaseIndex = Random.Range(0, BeveragesBase.Length);
            Beverages.Base = BeveragesBase[BaseIndex];
            Beverages.Picture = _view.BeveragesList[BaseIndex];
            
            Beverages.Topping = BeveragesTopping[Random.Range(0, BeveragesTopping.Length)];
            Beverages.ID = IDMaker.GenerateID();
            
            return Beverages;
        }

        public bool FoodAccopmlishment(FoodData Food)
        {
            List<CustomerController> CustomerList = GetAllCustomer();
            foreach(CustomerController Customer in CustomerList)
            {
                if (Customer.FoodServing(Food))
                {
                    if (Customer.CheckAccomplishment())
                    {
                        Customer.ServingComplete();
                        RemoveCustomer(Customer);
                    }

                    return true;
                }
            }
            return false;
        }

        public bool BeveragesAccomplishment(BeveragesData Beverages)
        {
            List<CustomerController> CustomerList = GetAllCustomer();
            foreach (CustomerController Customer in CustomerList)
            {
                if (Customer.BevaragesServing(Beverages))
                {
                    
                    if (Customer.CheckAccomplishment())
                    {
                        Customer.ServingComplete();
                        RemoveCustomer(Customer);
                    }

                    return true;
                }
            }
            return false;
        }

        //testing need to change
        public List<CustomerController> GetAllCustomer()
        {
            return _model.CustomerList;
        }

        public void RemoveCustomer(CustomerController Customer)
        {
            _model.RemoveCustomerData(Customer);
        }
        
    }
}

