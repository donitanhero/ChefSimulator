using Script.Module.ToppingModule.Topping;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Module.ToppingModule.ToppingContainer
{
    public class ToppingContainerView : MonoBehaviour
    {
        public ToppingView Prefab;

        public void InitiationRenderView(IToppingContainerModel IModel)
        {

        }

        public void UpdateRenderView(IToppingContainerModel IModel)
        {

        }

        public ToppingView Instantiate()
        {
            return Instantiate(Prefab, transform);
        }
    }
}

