using Script.Module.ToppingModule.Topping;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Module.ToppingModule.ToppingContainer
{
    public interface IToppingContainerModel
    {
        List<ToppingController> ToppingList { get; }
    }

    public class ToppingContainerModel: IToppingContainerModel
    {
        #region Constructor
        private ToppingContainerView _view;
        public void SetView(ToppingContainerView View)
        {
            _view = View;
        }

        private void SetDataAsDirty()
        {
            _view.UpdateRenderView(this);
        }
        #endregion

        public List<ToppingController> ToppingList { get; protected set; } = new List<ToppingController>();

        public void AddToppingList(ToppingController Topping)
        {
            ToppingList.Add(Topping);
        }

        public List<ToppingController> GetAllTopping()
        {
            return ToppingList;
        }


    }
}

