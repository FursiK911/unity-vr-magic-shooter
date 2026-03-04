using System;
using Input;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

namespace Player.Input
{
    public class PlayerInputHandler : IDisposable
    {
        private XRIInputActions _inputActions;
        
        private IXRControllerInputHandler _leftController;
        private IXRControllerInputHandler _rightController;

        public event Action<InteractorHandedness> ActivatePerformed;
        public event Action<InteractorHandedness> ActivateCanceled;

        public void Initialize()
        {
            _inputActions = new XRIInputActions();
            _leftController = new XRLeftControllerInputHandler(_inputActions.XRILeftInteraction);
            _rightController = new XRRightControllerInputHandler(_inputActions.XRIRightInteraction);
            
            _inputActions.Enable();
            _leftController.Enable();
            _rightController.Enable();
            
            _leftController.ActivatePerformed += LeftControllerOnActivatePerformed;
            _leftController.ActivateCanceled += LeftControllerOnActivateCanceled;
            
            _rightController.ActivatePerformed += RightControllerOnActivatePerformed;
            _rightController.ActivateCanceled += RightControllerOnActivateCanceled;
        }

        private void RightControllerOnActivateCanceled()
        {
            ActivateCanceled?.Invoke(InteractorHandedness.Right);
        }

        private void RightControllerOnActivatePerformed()
        {
            ActivatePerformed?.Invoke(InteractorHandedness.Right);
        }

        private void LeftControllerOnActivateCanceled()
        {
            ActivateCanceled?.Invoke(InteractorHandedness.Left);
        }

        private void LeftControllerOnActivatePerformed()
        {
            ActivatePerformed?.Invoke(InteractorHandedness.Left);
        }

        public void Dispose()
        {
            _leftController.ActivatePerformed -= LeftControllerOnActivatePerformed;
            _leftController.ActivateCanceled -= LeftControllerOnActivateCanceled;
            
            _rightController.ActivatePerformed -= RightControllerOnActivatePerformed;
            _rightController.ActivateCanceled -= RightControllerOnActivateCanceled;
            
            _inputActions?.Dispose();
            _leftController?.Dispose();
            _rightController?.Dispose();
        }
    }
}