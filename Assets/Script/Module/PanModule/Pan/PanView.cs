using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Script.Module.PanModule.Pan
{
    public class PanView : MonoBehaviour
    {
        public string Base;
        public Action TimerAction;
        public Action CookingDone;
        public Action OverCookingDone;
        public double Timer;
        public Button PanButton;
        public Image BaseImage;

        public void InitiationRenderView(IPanModel IModel)
        {


        }

        public void UpdateRenderView(IPanModel IModel)
        {
            Base = IModel.Base;
            
            //start cooking
            if (IModel.Cooking && IModel.Success == false)
            {
                //pan start the timer
                TimerAction = null;
                Timer = IModel.CookDuration;
                TimerAction += CooldownCooking;
                BaseImage.gameObject.SetActive(true);
                BaseImage.sprite = IModel.Image;
                BaseImage.color = new Color(1f, 1f, 1f);

                //picture change

            }
            else if (IModel.Cooking && IModel.OverCook) //food already overcook
            {
                TimerAction = null;
                BaseImage.color = new Color(51f / 255f, 51f / 255f, 49f / 255f);
            }
            else if (IModel.Cooking && IModel.Success) //food already cook
            {
                TimerAction = null;
                Timer = IModel.OverCookDuration;
                TimerAction += CooldownOverCook;
                BaseImage.color = new Color(255f/255f, 205f/255f, 0f/255f);
            }
            
            else
            {
                BaseImage.gameObject.SetActive(false);
            }
        }

        public void CooldownCooking()
        {
            if(Timer >0)
            {
                Timer -= Time.deltaTime;
            }
            else
            {
                Timer = 0;
                CookingDone.Invoke();
            }
        }

        public void CooldownOverCook()
        {
            if (Timer > 0)
            {
                Timer -= Time.deltaTime;
            }
            else
            {
                Timer = 0;
                TimerAction = null;
                OverCookingDone.Invoke();  
            }
        }

        public void PanButtonAddListener(UnityAction action)
        {
            PanButton.onClick.RemoveAllListeners();
            PanButton.onClick.AddListener(action);
        }

        private void Update()
        {
            if(TimerAction != null)
            {
                TimerAction.Invoke();
            }
        }
    }
}

