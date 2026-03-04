using System;
using Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Input
{
    public class XRRightControllerInputHandler: IXRControllerInputHandler, XRIInputActions.IXRIRightInteractionActions
    {
        private XRIInputActions.XRIRightInteractionActions _inputActions;

        public event Action ActivatePerformed;
        public event Action ActivateCanceled;
        
        public XRRightControllerInputHandler(XRIInputActions.XRIRightInteractionActions inputActions)
        {
            _inputActions =  inputActions;
            _inputActions.AddCallbacks(this);
        }
        
        public void Enable()
        {
            _inputActions.Enable();
        }

        public void Disable()
        {
            _inputActions.Disable();
        }
        
        public void Dispose()
        {
            _inputActions.RemoveCallbacks(this);
        }

        public void OnSelect(InputAction.CallbackContext context)
        {
            
        }

        public void OnSelectValue(InputAction.CallbackContext context)
        {
            
        }

        public void OnActivate(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                ActivatePerformed?.Invoke();
            }
            else if (context.canceled)
            {
                ActivateCanceled?.Invoke();
            }
        }

        public void OnActivateValue(InputAction.CallbackContext context)
        {
            
        }

        public void OnUIPress(InputAction.CallbackContext context)
        {
            
        }

        public void OnUIPressValue(InputAction.CallbackContext context)
        {
            
        }

        public void OnUIScroll(InputAction.CallbackContext context)
        {
            
        }

        public void OnTranslateManipulation(InputAction.CallbackContext context)
        {
            
        }

        public void OnRotateManipulation(InputAction.CallbackContext context)
        {
            
        }

        public void OnManipulation(InputAction.CallbackContext context)
        {
            
        }

        public void OnScaleToggle(InputAction.CallbackContext context)
        {
            
        }

        public void OnScaleOverTime(InputAction.CallbackContext context)
        {
            
        }
    }
}