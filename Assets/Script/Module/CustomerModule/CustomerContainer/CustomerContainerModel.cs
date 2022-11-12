using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Script.Module.CustomerModule.Customer;

namespace Script.Module.CustomerModule.CustomerContainer
{
    public interface ICustomerContainerModel
    {
        List<CustomerController> CustomerList { get; }
    }

    public class CustomerContainerModel: ICustomerContainerModel
    {

        #region Constructor
        private CustomerContainerView _view;
        private ICustomerContainerModel _model;

        public void SetView(CustomerContainerView View)
        {
            _view = View;
        }

        private void SetDataAsDirty()
        {
            _view.UpdateRenderView(this);
        }
        #endregion

        public List<CustomerController> CustomerList { get; protected set; } = new List<CustomerController>();

        public void AddCustomerData(CustomerController Customer)
        {
            CustomerList.Add(Customer);
            SetDataAsDirty();
        }

        public void RemoveCustomerData(CustomerController Customer)
        {
            
            CustomerList.Remove(Customer);
            SetDataAsDirty();
        }


    }
}

