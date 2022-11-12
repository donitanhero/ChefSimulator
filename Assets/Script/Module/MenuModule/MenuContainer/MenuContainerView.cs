using Script.Module.MenuModule.Menu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Module.MenuModule.MenuContainer
{
    public class MenuContainerView : MonoBehaviour
    {
        public MenuView FoodMenuPrefab;
        public MenuView BeveragesMenuPrefab;


        public Sprite[] FoodBase;
        public Sprite[] FoodTopping;
        public Sprite[] BeveragesBase;

        public void InitiationRenderView(IMenuContainerModel IModel)
        {

        }

        public void UpdateRenderView(IMenuContainerModel IModel)
        {
         
        }

        public MenuView InstantiateFood()
        {
            return Instantiate(FoodMenuPrefab, transform);
        }

        public MenuView InstantiateBeverages()
        {
            return Instantiate(BeveragesMenuPrefab, transform);
        }
        


    }
}

