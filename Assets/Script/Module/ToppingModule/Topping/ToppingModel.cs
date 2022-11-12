using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Module.ToppingModule.Topping
{
    public interface IToppingModel
    {
        string Topping { get; }
        Image Picture { get; }
    }

    public class ToppingModel : IToppingModel
    {
        #region Constructor
        private ToppingView _view;

        public void SetView(ToppingView View)
        {
            _view = View;
        }
        private void SetDataAsDirty()
        {
            _view.UpdateRenderView(this);
        }
        #endregion

        private string _topping;
        private Image _picture;

        public void SetTopping(string topping)
        {
            _topping = topping;
            SetDataAsDirty();
        }

        public void SetPicture(Image img)
        {
            _picture = img;
            SetDataAsDirty();
        }

        public string GetTopping()
        {
            return _topping;
        }

        public Image GetPicture()
        {
            return _picture;
        }

        #region Interfaces

        public string Topping
        {
            get
            {
                return _topping;
            }
        }

        public Image Picture
        {
            get
            {
                return _picture;
            }
        }

        #endregion
    }
}

