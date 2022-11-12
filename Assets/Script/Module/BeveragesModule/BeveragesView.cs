using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Script.Module.Beverages
{
    public class BeveragesView : MonoBehaviour
    {
        public Button BeveragesButton;
        public Sprite BeveragesImage;
        public void AddBeveragesButtonListener(UnityAction Action)
        {
            BeveragesButton.onClick.RemoveAllListeners();
            BeveragesButton.onClick.AddListener(Action);
        }

        public void StartCooldown()
        {
            StartCoroutine(ButtonCooldown());
        }

        IEnumerator ButtonCooldown()
        {
            BeveragesButton.interactable = false;
            yield return new WaitForSeconds(2);
            BeveragesButton.interactable = true;

        }
    }
}

