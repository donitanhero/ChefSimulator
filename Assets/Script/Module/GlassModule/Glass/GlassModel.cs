using Script.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Module.GlassModule.Glass
{
    public interface IGlassModel
    {
        BeveragesData Beverages { get; }
    }

    public class GlassModel : IGlassModel
    {
        #region Constructor
        private GlassView _view;
        public void SetView(GlassView View)
        {
            _view = View;
        }
        private void SetDataAsDirty()
        {
            _view.UpdateRenderView(this);
        }
        #endregion

        private BeveragesData _beverages= new BeveragesData();
        public void SetBeverages(BeveragesData beverages)
        {
            _beverages = beverages;
            SetDataAsDirty();
        }

        public BeveragesData GetBeverages()
        {
            return _beverages;
        }

        public BeveragesData Beverages
        {
            get
            {
                return _beverages;
            }
        }
        


    }
}

