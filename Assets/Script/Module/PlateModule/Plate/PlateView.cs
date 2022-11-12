using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Script.Module.PlateModule.Plate
{

    public class PlateView : MonoBehaviour
    {
        public string Food;
        public Button PlateButton;
        public Sprite[] ToppingListImage;
        public Image Base;
        public Image Topping;

        public void InitiationRenderView(IPlateModel IModel)
        {

        }

        public void UpdateRenderView(IPlateModel IModel)
        {
            Food = IModel.Food.Base + " " + IModel.Food.Topping;

            if(IModel.Food.Base != "")
            {
                Base.gameObject.SetActive(true);
                Base.sprite = IModel.Food.Picture;
                Base.color = new Color(255f / 255f, 205f / 255f, 0f / 255f); ;
            }
            else
            {
                Base.gameObject.SetActive(false);
                
            }

            if (IModel.Food.Topping != "")
            {
                Topping.gameObject.SetActive(true);
                Topping.sprite = IModel.Food.ToppingPicture;
            }
            else
            {
                Topping.gameObject.SetActive(false);
            }

        }

        public void AddPlateButtonListener(UnityAction Action)
        {
            PlateButton.onClick.RemoveAllListeners();
            PlateButton.onClick.AddListener(Action);
        }
    }
}

