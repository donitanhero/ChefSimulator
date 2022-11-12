using Script.Data;
using Script.Module.PlateModule.Plate;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Module.PlateModule.PlateContainer
{
    public class PlateContainerController
    {
        private PlateContainerView _view;
        private PlateContainerModel _model;
        public void Constructor(PlateContainerView View)
        {
            _view = View;
            _model = new PlateContainerModel();
            _model.SetView(_view);

            _view.InitiationRenderView(_model);
            Initiation();
        }

        public void Initiation()
        {
            CreatePlate();
            CreatePlate();
            CreatePlate();
            CreatePlate();
        }

        public void CreatePlate()
        {
            PlateController Plate = new PlateController();
            Plate.Constructor(_view.Instantiate());
            AddPlateList(Plate);
        }

        public void AssignPlateBase(FoodData Food)
        {
            List<PlateController> PlateList = GetPlateList();
            foreach(PlateController Plate in PlateList)
            {
                if (Plate.CheckPlateEmpty())
                {
                    Plate.SetFood(Food);
                    break;
                }
            }
        }

        public void AssignPlateTopping(string Topping, Sprite Image)
        {
            List<PlateController> PlateList = GetPlateList();
            foreach (PlateController Plate in PlateList)
            {
                if (Plate.CheckToppingEmpty() && Plate.CheckPlateEmpty() == false)
                {
                    Plate.AddTopping(Topping, Image);
                    break;
                }
            }
        }


        public void AddPlateList(PlateController Plate)
        {
            _model.AddPlateList(Plate);
        }

        public List<PlateController> GetPlateList()
        {
            return _model.GetPlateList();
        }

    }
}

