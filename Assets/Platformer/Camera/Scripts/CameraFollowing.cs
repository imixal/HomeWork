using UnityEngine;

namespace Platformer.Camera.Scripts
{
    public class CameraFollowing : MonoBehaviour
    {
        
        public Transform camTarget;
        
        [Range(1, 100)]
        
        public float trackingSpeed;

        
        void FixedUpdate() 
        {
            if(camTarget == null)
                return;
            
            var newPos = Vector2.Lerp(transform.position,
                camTarget.position,
                
                Time.deltaTime * trackingSpeed);
         
            transform.position = new Vector3(newPos.x, newPos.y, -10f);
        }
    }
}