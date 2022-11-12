using Script.Data;
using Script.Module.MenuModule.MenuContainer;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Module.CustomerModule.Customer
{
    public class CustomerView : MonoBehaviour
    {
        public Image CustomerImage;
        public string Food;
        public bool FoodStatus;
        public MenuContainerView MenuContainer;
        public Action WaitingEnd;
        public float WaitingTime;

        public void InitiationRenderView(ICustomerModel IModel)
        {

        }

        public void UpdateRenderView(ICustomerModel IModel)
        {
            CustomerImage.sprite = IModel.CustomerImage;
            
            
        }

        public void CustomerDestroy()
        {
            Destroy(gameObject);
        }

        public void StartWaiting(float Time)
        {
            WaitingTime = Time;
            StartCoroutine(CustomerWaiting());

        }

        IEnumerator CustomerWaiting()
        {
            yield return new WaitForSeconds(WaitingTime);
            WaitingEnd.Invoke();
        }

    }
}

