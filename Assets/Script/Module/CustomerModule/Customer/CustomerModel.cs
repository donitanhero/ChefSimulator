using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Script.Data;
using UnityEngine.UI;
namespace Script.Module.CustomerModule.Customer
{
    public interface ICustomerModel
    {
        List<FoodData> FoodList { get; }
        List<BeveragesData> BeveragesList { get; }
        Sprite CustomerImage { get; }
        string ID { get; }
    }

    public class CustomerModel: ICustomerModel
    {
        
        private Sprite _customerImage;
        private string _id;

        #region Constructor
        private CustomerView _view;
        private ICustomerModel _model;

        public void SetView(CustomerView View)
        {
            _view = View;
        }
        private void SetDataAsDirty()
        {
            _view.UpdateRenderView(this);
        }

        #endregion

        public List<FoodData> FoodList { get; protected set; } = new List<FoodData>();

        public List<BeveragesData> BeveragesList { get; protected set; } = new List<BeveragesData>();

        public void AddFood(FoodData Food)
        {
            FoodList.Add(Food);
            SetDataAsDirty();
        }

        public void AddBeverages(BeveragesData Beverages)
        {
            BeveragesList.Add(Beverages);
            SetDataAsDirty();
        }

        public void SetCustomerImage(Sprite Img)
        {
            _customerImage = Img;
            SetDataAsDirty();
        }

        public void SetFoodDone(string ID)
        {
            foreach(FoodData Food in FoodList)
            {
                if (Food.ID == ID)
                {
                    Food.Done = true;
                    break;
                }
            }
            SetDataAsDirty();
        }

        public void SetBeveragesDone(string ID)
        {
            foreach(BeveragesData Beverages in BeveragesList)
            {
                if(Beverages.ID == ID)
                {
                    Beverages.Done = true;
                    break;
                }
            }
            SetDataAsDirty();
        }

        public void SetID(string id)
        {
            _id = id;
            SetDataAsDirty();
        }

        public List<FoodData> GetAllFood()
        {
            return FoodList;
        }

        public List<BeveragesData> GetAllBeverages()
        {
            return BeveragesList;
        }

        public string GetID()
        {
            return _id;
        }

        #region Interfaces
        public Sprite CustomerImage
        {
            get
            {
                return _customerImage;
            }
        }

        public string ID
        {
            get
            {
                return _id;
            }
        }

        #endregion


    }
}

