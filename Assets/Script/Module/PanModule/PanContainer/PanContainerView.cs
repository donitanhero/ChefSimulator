using Script.Module.PanModule.Pan;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Module.PanModule.PanContainer
{
    public class PanContainerView : MonoBehaviour
    {

        public PanView Prefab;
         

        public void InitRenderView(IPanContainerModel IModel)
        {

        }

        public void UpdateRenderView(IPanContainerModel IModel)
        {
           
        }

        public PanView Instantiate()
        {
            return Instantiate(Prefab, transform);
        }

       
    }
}

