using Script.Module.GlassModule.Glass;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Module.GlassModule.GlassContainer
{
    public interface IGlassContainerModel
    {
        List<GlassController> GlassList { get; }
    }

    public class GlassContainerModel : IGlassContainerModel
    {
        #region Constructor
        private GlassContainerView _view;
        public void SetView(GlassContainerView View)
        {
            _view = View;
        }
        private void SetDataAsDirty()
        {
            _view.UpdateRenderView(this);
        }

        #endregion

        public List<GlassController> GlassList { get; protected set; } = new List<GlassController>();

        public void AddGlass(GlassController Glass)
        {
            GlassList.Add(Glass);
            SetDataAsDirty();
        }

        public List<GlassController> GetGlassList()
        {
            return GlassList;
        }
    }
}

