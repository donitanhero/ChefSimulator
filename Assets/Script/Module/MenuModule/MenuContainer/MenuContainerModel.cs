using Script.Data;
using Script.Module.MenuModule.Menu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Module.MenuModule.MenuContainer
{
    public interface IMenuContainerModel
    {
        List<MenuController> MenuList { get; }
        
    }

    public class MenuContainerModel: IMenuContainerModel
    {
        #region Constructor
        private MenuContainerView _view;
        public void SetView(MenuContainerView View)
        {
            _view = View;
        }
        private void SetDataAsDirty()
        {
            _view.UpdateRenderView(this);
        }
        #endregion

        public List<MenuController> MenuList { get; protected set; } = new List<MenuController>();

      
        public void AddMenu(MenuController Menu)
        {
            MenuList.Add(Menu);
            SetDataAsDirty();
        }


        public List<MenuController> GetAllMenu()
        {
            return MenuList;
        }

        public void RemoveMenu(MenuController Menu)
        {
            MenuList.Remove(Menu);
        }


    }
}


