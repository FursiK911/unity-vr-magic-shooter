using System;
using Input;
using UnityEngine.InputSystem;

namespace Player.Input
{
    public class XRLeftControllerInputHandler: IXRControllerInputHandler, XRIInputActions.IXRILeftInteractionActions
    {
        private XRIInputActions.XRILeftInteractionActions _inputActions;

        public event Action ActivatePerformed;
        public event Action ActivateCanceled;
        
        public XRLeftControllerInputHandler(XRIInputActions.XRILeftInteractionActions inputActions)
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
        
        void XRIInputActions.IXRILeftInteractionActions.OnSelect(InputAction.CallbackContext context)
        {
            
        }

        void XRIInputActions.IXRILeftInteractionActions.OnSelectValue(InputAction.CallbackContext context)
        {
            
        }

        void XRIInputActions.IXRILeftInteractionActions.OnActivate(InputAction.CallbackContext context)
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

        void XRIInputActions.IXRILeftInteractionActions.OnActivateValue(InputAction.CallbackContext context)
        {
            
        }

        void XRIInputActions.IXRILeftInteractionActions.OnUIPress(InputAction.CallbackContext context)
        {
            
        }

        void XRIInputActions.IXRILeftInteractionActions.OnUIPressValue(InputAction.CallbackContext context)
        {
            
        }

        void XRIInputActions.IXRILeftInteractionActions.OnUIScroll(InputAction.CallbackContext context)
        {
            
        }

        void XRIInputActions.IXRILeftInteractionActions.OnTranslateManipulation(InputAction.CallbackContext context)
        {
            
        }

        void XRIInputActions.IXRILeftInteractionActions.OnRotateManipulation(InputAction.CallbackContext context)
        {
            
        }

        void XRIInputActions.IXRILeftInteractionActions.OnManipulation(InputAction.CallbackContext context)
        {
            
        }

        void XRIInputActions.IXRILeftInteractionActions.OnScaleToggle(InputAction.CallbackContext context)
        {
            
        }

        void XRIInputActions.IXRILeftInteractionActions.OnScaleOverTime(InputAction.CallbackContext context)
        {
            
        }
    }
}