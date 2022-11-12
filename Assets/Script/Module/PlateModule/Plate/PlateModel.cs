using Script.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Script.Module.PlateModule.Plate
{
    public interface IPlateModel
    {
        FoodData Food { get; }
    }
    public class PlateModel : IPlateModel
    {
        #region Constructor
        private PlateView _view;
        public void SetView(PlateView View)
        {
            _view = View;
        }
        private void SetDataAsDirty()
        {
            _view.UpdateRenderView(this);
        }
        #endregion

        private FoodData _food = new FoodData();

        public void SetFood(FoodData food)
        {
            _food = food;
            SetDataAsDirty();
        }

        public FoodData GetFood()
        {
            return _food;
        }

        public FoodData Food
        {
            get
            {
                return _food;
            }
        }
    }
}

