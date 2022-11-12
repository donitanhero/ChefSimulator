using Script.Module.PlateModule.Plate;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Module.PlateModule.PlateContainer
{
    public class PlateContainerView : MonoBehaviour
    {
        public PlateView Prefab;
        public void InitiationRenderView(IPlateContainerModel IModel)
        {

        }

        public void UpdateRenderView(IPlateContainerModel IModel)
        {

        }

        public PlateView Instantiate()
        {
            return Instantiate(Prefab, transform);
        }
    }
}

