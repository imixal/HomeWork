using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.MainPlayer.Scripts
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField]
        private float checkRadius;
        [SerializeField]
        private LayerMask layerGround;

        public bool IsGrounded()
        {
            return Physics2D.OverlapCircle(transform.position, checkRadius, layerGround);
        }
    }