using UnityEngine;

namespace Platformer.DynamicBackground.Scripts
{
    public class Parallax : MonoBehaviour
    {
        
        private float _lenght;
        
        private float _startPosition;
    
         
        [Range(0, 1)]
       
        public float parallaxEffect;
       
        public GameObject mainCamera;

        void Start()
        {
            _startPosition = transform.position.x;
           
            _lenght = GetComponent<SpriteRenderer>().bounds.size.x;
        }
        
        
        void FixedUpdate()
        {
            var dist = mainCamera.transform.position.x * parallaxEffect;
           
            transform.position = new Vector3(
                _startPosition + dist, 
                transform.position.y, 
                transform.position.z);
            
            
            var temp = mainCamera.transform.position.x * (1 - parallaxEffect);
            if (temp > _startPosition + _lenght)
                _startPosition += _lenght;
            else if (temp < _startPosition) _startPosition -= _lenght;
        }
    }
}