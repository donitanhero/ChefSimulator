using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Script.Module.CustomerModule.Customer;
using System;

namespace Script.Module.CustomerModule.CustomerContainer
{
    public class CustomerContainerView : MonoBehaviour
    {
        public CustomerView CustomerPrefab;
        public Action CreateCustomer; 

        public Sprite[] FoodBaseList;
        public Sprite[] FoodToppingList;
        public Sprite[] BeveragesList;
        public Sprite[] CustomerPicture;

        public float CooldownSpawn;
        public int MaxCustomer;

        public void InitiationRenderView(ICustomerContainerModel IModel)
        {
            StartCoroutine(waitSpawner());
        }

        public void UpdateRenderView(ICustomerContainerModel IModel)
        {

        }

        public CustomerView Instantiate()
        {
            return Instantiate(CustomerPrefab, transform);
        }

        IEnumerator waitSpawner()
        {
            yield return new WaitForSeconds(5);
            int counter = 0;
            while (counter <MaxCustomer)
            {
                CreateCustomer.Invoke();
                counter++;
                yield return new WaitForSeconds(CooldownSpawn);
            }
        }
    }
}

