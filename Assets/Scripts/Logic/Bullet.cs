using UnityEngine;

namespace Logic
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private void Update()
        {
            transform.position += Vector3.right * _speed * Time.deltaTime;
        }
    }
}