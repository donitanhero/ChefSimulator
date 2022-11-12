using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Module.MenuModule.Menu
{
    public class MenuView : MonoBehaviour
    {
        public Image Base;
        public Image Topping;

        public void InitiationRenderView(IMenuModel IModel)
        {

        }

        public void UpdateRenderView(IMenuModel IModel)
        {
            if(IModel.Type == "Food")
            {
                Base.gameObject.SetActive(true);
                Base.sprite = IModel.Food.Picture;

                if(IModel.Food.Topping != "")
                {
                    Topping.gameObject.SetActive(true);
                    Topping.sprite = IModel.Food.ToppingPicture;
                }
                
            }
            else if(IModel.Type == "Beverages")
            {
                Base.gameObject.SetActive(true);
                Base.sprite = IModel.Beverages.Picture;
            }
        }

        public void DestroyMenu()
        {
            Destroy(gameObject);
        }
    }
}

