using UnityEngine;

namespace Platformer.Camera.Scripts
{
    public class CameraFollowing : MonoBehaviour
    {
        //Создаем поле: в которое мы будет класть игровой объект на сцене, за которым будет следовать камера
        public Transform camTarget;
        //Помечаем наше поле специальным атрибутом, который будет использовать редактор, для ограничения выставляемых значений
        [Range(1, 100)]
        //Здесь мы будем хранить скорость, с которой камера будет следовать за персонажем (100 - она будет всегда на нем, 1 - будет его догонять)
        public float trackingSpeed;

        //Функция вызываемая Unity, не зависящая от частоты кадров.
        void FixedUpdate() 
        {
            if(camTarget == null)
                return;
            //Рассчитываем новую позици
            //функция Lerp — это и это фукнция линейной интерполяции
            var newPos = Vector2.Lerp(transform.position,
                camTarget.position,
                //Time.deltaTime временной интервал между вызовамии FixedUpdate
                Time.deltaTime * trackingSpeed);
            //Меняем позицию камеры
            transform.position = new Vector3(newPos.x, newPos.y, -10f);
        }
    }
}