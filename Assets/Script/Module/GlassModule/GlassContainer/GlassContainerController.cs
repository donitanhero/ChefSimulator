using Script.Data;
using Script.Module.GlassModule.Glass;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Module.GlassModule.GlassContainer
{
    public class GlassContainerController
    {
        #region Constructor
        private GlassContainerView _view;
        private GlassContainerModel _model;
        public void Constructor(GlassContainerView View)
        {
            _view = View;
            _model = new GlassContainerModel();
            _model.SetView(_view);

            _view.InitiationRenderView(_model);
            Initiation();
        }

    

        #endregion

        public void Initiation()
        {
            CreateGlass();
            CreateGlass();
            CreateGlass();

        }

        public void CreateGlass()
        {
            GlassController Glass = new GlassController();
            Glass.Constructor(_view.Instantiate());
            AddGlass(Glass);
        }

        public void AssignGlassBase(BeveragesData Beverages)
        {
            List<GlassController> GlassList = GetGlassList();
            foreach (GlassController Glass in GlassList)
            {
                if (Glass.CheckGlassEmpty())
                {
                    Glass.SetBeverages(Beverages);
                    break;
                }
            }
        }

        public void AddGlass(GlassController Glass)
        {
            _model.AddGlass(Glass);
        }

        public List<GlassController> GetGlassList()
        {
            return _model.GetGlassList();
        }

    }
}

