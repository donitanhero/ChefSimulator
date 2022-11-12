using Script.Module.GlassModule.Glass;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Module.GlassModule.GlassContainer
{
    public class GlassContainerView : MonoBehaviour
    {
        public GlassView Prefab;
        

        public void InitiationRenderView(IGlassContainerModel IModel)
        {

        }

        public void UpdateRenderView(IGlassContainerModel IModel)
        {

        }

        public GlassView Instantiate()
        {
            return Instantiate(Prefab, transform);
        }
    }
}

