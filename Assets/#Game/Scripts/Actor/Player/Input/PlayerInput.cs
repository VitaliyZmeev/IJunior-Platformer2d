using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Platformer2d
{
    public class PlayerInput : MonoBehaviour
    {
        private InputActions _inputActions;
        private bool _isJump;

        public event Action JumpPerformed;
        public event Action HitPerformed;
        public event Action LifeStealAbilityPerformed;

        private void Awake()
        {
            _inputActions = new InputActions();
        }

        private void OnEnable()
        {
            _inputActions.Enable();
            _inputActions.Player.Jump.performed += OnJumpPerformed;
            _inputActions.Player.Hit.performed += OnHitPerformed;
            _inputActions.Player.LifeStealAbility.performed += OnLifeStealAbilityPerformed;
        }

        private void OnDisable()
        {
            _inputActions.Disable();
            _inputActions.Player.Jump.performed -= OnJumpPerformed;
            _inputActions.Player.Hit.performed -= OnHitPerformed;
            _inputActions.Player.LifeStealAbility.performed -= OnLifeStealAbilityPerformed;
        }

        public float GetMoveDirection()
        {
            return _inputActions.Player.Move.ReadValue<float>();
        }

        public bool IsJump()
        {
            return GetBoolAsTrigger(ref _isJump);
        }

        private bool GetBoolAsTrigger(ref bool value)
        {
            bool localValue = value;
            value = false;

            return localValue;
        }

        private void OnJumpPerformed(InputAction.CallbackContext context)
        {
            _isJump = true;
            JumpPerformed?.Invoke();
        }

        private void OnHitPerformed(InputAction.CallbackContext context)
        {
            HitPerformed?.Invoke();
        }

        private void OnLifeStealAbilityPerformed(InputAction.CallbackContext context)
        {
            LifeStealAbilityPerformed?.Invoke();
        }
    }
}