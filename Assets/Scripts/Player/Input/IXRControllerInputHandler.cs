using System;

namespace Player.Input
{
    public interface IXRControllerInputHandler: IDisposable
    {
        public void Enable();
        public void Disable();
        
        public event Action ActivatePerformed;
        public event Action ActivateCanceled;
    }
}