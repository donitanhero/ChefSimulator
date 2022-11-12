using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Script.Module.ToppingModule.Topping
{
    public class ToppingView : MonoBehaviour
    {
        public Image ToppingImage;
        public Button ToppingButton;

        public void InitiationRenderView(IToppingModel IModel)
        {

        }

        public void UpdateRenderView(IToppingModel IModel)
        {

        }

        public void ToppingButtonAddListener(UnityAction Action)
        {
            ToppingButton.onClick.RemoveAllListeners();
            ToppingButton.onClick.AddListener(Action);
        }
    }
}

