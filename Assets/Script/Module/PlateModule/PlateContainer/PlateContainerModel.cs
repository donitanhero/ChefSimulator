using Script.Module.PlateModule.Plate;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Module.PlateModule.PlateContainer
{
    public interface IPlateContainerModel
    {
        List<PlateController> PlateList { get; }
    }

    public class PlateContainerModel : IPlateContainerModel
    {
        #region Constructor
        private PlateContainerView _view;
        public void SetView(PlateContainerView View)
        {
            _view = View;
        }
            
        private void SetDataAsDirty()
        {
            _view.UpdateRenderView(this);
        }
        #endregion

        public List<PlateController> PlateList { get; protected set; } = new List<PlateController>();

        public void AddPlateList(PlateController Plate)
        {
            PlateList.Add(Plate);
        }

        public List<PlateController> GetPlateList()
        {
            return PlateList;
        }
    }
}


