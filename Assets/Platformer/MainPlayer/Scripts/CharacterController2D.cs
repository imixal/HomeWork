using System;
using Core.Scripts.Input;
using UnityEngine;

namespace Platformer.MainPlayer.Scripts
{
    public class CharacterController2D : MonoBehaviour
    {
        public float speed = 14f;
        public float accel = 6f;
        public float jumpForce = 100f;

        private float _direction;
        private Rigidbody2D _rb;
        private bool _facingRight = true;
        private GroundChecker _groundChecker;
        private Animator _animator;
    
        void Awake() 
        {
            _rb = GetComponent<Rigidbody2D>();
            _groundChecker = GetComponentInChildren<GroundChecker>();
            _animator = GetComponent<Animator>();
        }

        void Update()
        {
            var isGround = _groundChecker.IsGrounded();
            _direction = CrossPlatformInputManager.GetAxis("Horizontal");
            if(CrossPlatformInputManager.GetButtonDown("Jump") && _rb.velocity.y == 0 && isGround)
                _rb.AddForce(Vector2.up * jumpForce);
            
            if(Math.Abs(_direction) > 0 && _rb.velocity.y == 0 && isGround)
                _animator.SetBool("isRunning", true);
            else
                _animator.SetBool("isRunning", false);

            if (_rb.velocity.y == 0 && isGround)
            {
                _animator.SetBool("isJumping", false);
                _animator.SetBool("isFalling", false);
            }
            
            if(_rb.velocity.y > 0)
                _animator.SetBool("isJumping", true);

            if (_rb.velocity.y < 0)
            {
                _animator.SetBool("isJumping", false);
                _animator.SetBool("isFalling", true);
            }
        }
        
        void FixedUpdate()
        {
            _rb.AddForce(new Vector2((_direction * speed - _rb.velocity.x) * accel, _rb.velocity.y));
        }

        private void LateUpdate()
        {
            if(_direction > 0 && !_facingRight)
                Flip();
            else if(_direction < 0 && _facingRight)
                Flip();
        }

        void Flip()
        {
            var localScale = transform.localScale;
            transform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
            _facingRight = !_facingRight;
        }
    }
}
