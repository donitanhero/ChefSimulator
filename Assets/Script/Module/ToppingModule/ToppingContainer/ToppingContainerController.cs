using Script.Module.ToppingModule.Topping;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Module.ToppingModule.ToppingContainer
{
    public class ToppingContainerController
    {
        private ToppingContainerModel _model;
        private ToppingContainerView _view;

        public string[] FoodTopping = new string[] { "Cokelat"};

        public void Constructor(ToppingContainerView View)
        {
            _view = View;
            _model = new ToppingContainerModel();
            _model.SetView(_view);

            Initiation();
        }

        private void Initiation()
        {
            foreach (string Topping in FoodTopping)
            {
                CreateTopping(Topping);
                //set picture
            }

        }

        public void CreateTopping(string Topping)
        {
            ToppingController NewTopping = new ToppingController();
            NewTopping.Constructor(_view.Instantiate());
            NewTopping.SetTopping(Topping);
            //set picture
            AddToppingList(NewTopping);
        }

        public void AddToppingList(ToppingController Topping)
        {
            _model.AddToppingList(Topping);
        }
    }
}

