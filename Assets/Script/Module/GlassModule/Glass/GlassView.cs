using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Script.Module.GlassModule.Glass
{
    public class GlassView : MonoBehaviour
    {
        public string Glass;
        public Button GlassButton;
        public Image GlassBaseImage;
        public void InitiationRenderView(IGlassModel IModel)
        {

        }

        public void UpdateRenderView(IGlassModel IModel)
        {
            Glass = IModel.Beverages.Base;
            if(IModel.Beverages.Base != "")
            {
                GlassBaseImage.gameObject.SetActive(true);
                GlassBaseImage.sprite = IModel.Beverages.Picture;
            }
            else
            {
                GlassBaseImage.gameObject.SetActive(false);
            }
            
        }

        public void AddGlassButtonListener(UnityAction Action)
        {
            GlassButton.onClick.RemoveAllListeners();
            GlassButton.onClick.AddListener(Action);
        }
    }
}

