using System.Collections.Generic;
using NUnit.Framework;
using Player.Input;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Magic Shooters")]
        [SerializeField]
        private MagicShooter _leftMagicShooter;
        [SerializeField]
        private MagicShooter _rightMagicShooter;

        private PlayerInputHandler _input;
        
        private Dictionary<InteractorHandedness, MagicShooter> _magicShooters;
        
        public void Initialize()
        {
            _input = new PlayerInputHandler();
            
            _input.Initialize();
            _leftMagicShooter.Initialize();
            _rightMagicShooter.Initialize();

            _magicShooters = new Dictionary<InteractorHandedness, MagicShooter>()
            {
                { InteractorHandedness.Left, _leftMagicShooter },
                { InteractorHandedness.Right, _rightMagicShooter }
            };

            Subscribes();
        }

        private void OnDestroy()
        {
            Unsubscribes();
            _input.Dispose();
        }

        private void Subscribes()
        {
            _input.ActivatePerformed += HandleActivatePerformed;
            _input.ActivateCanceled += HandleActivateCanceled;
        }
        
        private void Unsubscribes()
        {
            _input.ActivatePerformed -= HandleActivatePerformed;
            _input.ActivateCanceled -= HandleActivateCanceled;
        }
        
        private void HandleActivatePerformed(InteractorHandedness handedness)
        {
            if (_magicShooters.TryGetValue(handedness, out var magicShooter))
            {
                //Debug.Log("Magic Shooter Performed");
                magicShooter.Shoot(Vector3.forward);
            }
        }

        private void HandleActivateCanceled(InteractorHandedness handedness)
        {
            if (_magicShooters.TryGetValue(handedness, out var magicShooter))
            {
                //Debug.Log("Magic Shooter Canceled");
            }
        }
        
        private void OnValidate()
        {
            Assert.NotNull(_leftMagicShooter, "LeftMagicShooter is null");
            Assert.NotNull(_rightMagicShooter, "RightMagicShooter is null");
        }
    }
}