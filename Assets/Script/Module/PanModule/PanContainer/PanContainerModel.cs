using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Script.Module.PanModule.Pan;

namespace Script.Module.PanModule.PanContainer
{
    public interface IPanContainerModel
    {
        List<PanController> PanList { get; }
    }

    public class PanContainerModel: IPanContainerModel
    {
        #region Constructor
        private PanContainerView _view;
        public void SetView(PanContainerView View)
        {
            _view = View;
        }
        private void SetDataAsDirty()
        {
            _view.UpdateRenderView(this);
        }
        #endregion


        public List<PanController> PanList { get; protected set; } = new List<PanController>();

        public void AddPan(PanController Pan)
        {
            PanList.Add(Pan);
            SetDataAsDirty();
        }

        public List<PanController> GetAllPan()
        {
            return PanList;
        }


    }
}

