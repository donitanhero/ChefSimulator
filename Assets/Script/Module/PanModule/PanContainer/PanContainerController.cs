using Script.Global.ID;
using Script.Global.Main.Launcher;
using Script.Module.PanModule.Pan;
using Script.Module.PlateModule.PlateContainer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Script.Module.PanModule.PanContainer
{
    public class PanContainerController
    {
        #region Constructor
        private PanContainerModel _model;
        private PanContainerView _view;

        public void Constructor(PanContainerView View)
        {
            _view = View;
            _model = new PanContainerModel();
            _model.SetView(_view);

            _view.InitRenderView(_model);
            IDMaker = MainLauncher.Instance.IDMaker;
            
            //temporary
            Initiation();
        }
        #endregion

        private IDGenerator IDMaker;
        

        private void Initiation()
        {
            CreatePan(3, 10);
            CreatePan(3, 10);
        }

        public void CreatePan(int CookDuration, int OverCookDuration)
        {
            PanController Pan = new PanController();
            Pan.Constructor(_view.Instantiate());
            Pan.SetCookDuration(CookDuration);
            Pan.SetOverCookDuration(OverCookDuration);
            //setpicture
            AddPan(Pan);
        }

        public void AssignPan(string Base, Sprite Image)
        {
           
            var PanList = GetAllPan();
            foreach(PanController Pan in PanList)
            {
                
                if (Pan.CheckPanEmpty())
                {
                    Pan.CookFood(Base, Image);
                    break;
                }
            }
        }

        public List<PanController> GetAllPan()
        {
            return _model.GetAllPan();
        }

        public void AddPan(PanController Pan)
        {
            _model.AddPan(Pan);
        }

    }
}

