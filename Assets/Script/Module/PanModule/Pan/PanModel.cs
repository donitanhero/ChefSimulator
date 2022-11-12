using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Module.PanModule.Pan
{
    public interface IPanModel
    {
        bool Cooking { get; }
        string Base { get; }
        int CookDuration { get; }
        int OverCookDuration { get; }
        bool Success { get; }
        string ID { get; }
        bool OverCook { get; }
        Sprite Image { get; }
    }

    public class PanModel : IPanModel
    {
        #region Constructor
        private PanView _view;
        public void SetView(PanView View)
        {
            _view = View;
        }

        private void SetDataAsDirty()
        {
            _view.UpdateRenderView(this);
        }
        #endregion

        private bool _cooking;
        private string _base;
        private int _cookDuration;
        private int _overCookDuration;
        private bool _success;
        private string _id;
        private bool _overcook;
        private Sprite _image;

        #region Set Method
        public void SetCooking(bool Cook)
        {
            _cooking = Cook;
            SetDataAsDirty();
        }

        public void SetBase(string FoodBase)
        {
            _base = FoodBase;
            SetDataAsDirty();
        }

        public void SetCookDuration(int Duration)
        {
            _cookDuration = Duration;
            SetDataAsDirty();
        }

        public void SetOverCookDuration(int Duration)
        {
            _overCookDuration = Duration;
            SetDataAsDirty();
        }
        public void SetSuccess(bool PanSuccess)
        {
            _success = PanSuccess;
            SetDataAsDirty();
        }

        public void SetID(string id)
        {
            _id = id;
        }

        public void SetOverCook(bool PanOverCook)
        {
            _overcook = PanOverCook;
            SetDataAsDirty();
        }

        public void SetImage(Sprite image)
        {
            _image = image;
            SetDataAsDirty();
        }

        #endregion

        #region Get Method

        public bool GetCooking()
        {
            return _cooking;
        }

        public string GetBase()
        {
            return _base;
        }

        public int GetCookDuration()
        {
            return _cookDuration;
        }

        public int GetOverCookDuration()
        {
            return _overCookDuration;
        }

        public bool GetSuccess()
        {
            return _success;
        }

        public string GetID()
        {
            return _id;
        }

        public bool GetOverCook()
        {
            return _overcook;
        }
        public Sprite GetImage()
        {
            return _image;
        }

        #endregion

        #region Interfaces
        public bool Cooking
        {
            get
            {
                return _cooking;
            }
        }

        public string Base
        {
            get
            {
                return _base;
            }
        }

        public int CookDuration
        {
            get
            {
                return _cookDuration;
            }
        }

        public int OverCookDuration
        {
            get
            {
                return _overCookDuration;
            }
        }

        public bool Success
        {
            get
            {
                return _success;
            }
        }

        public string ID
        {
            get
            {
                return _id;
            }
        }

        public bool OverCook
        {
            get
            {
                return _overcook;
            }
        }

        public Sprite Image
        {
            get
            {
                return _image;
            }
        }
        #endregion
    }

}
