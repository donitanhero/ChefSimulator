using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Script.Module.Dough
{
    public class DoughView : MonoBehaviour
    {
        public Button DoughButton;
        public Sprite DoughFoodImage;

        public void AddDoughButtonListener(UnityAction Action)
        {
            DoughButton.onClick.RemoveAllListeners();
            DoughButton.onClick.AddListener(Action);
        }
    }
}

