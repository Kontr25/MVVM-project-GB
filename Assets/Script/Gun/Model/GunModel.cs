using UnityEngine;

namespace Script.Gun.Model
{
    public class GunModel: MonoBehaviour, IGun
    {
        public Transform _shotPoint { get; set; }
        public Transform _gun { get; set; }
        public Rigidbody _bullet { get; set; }

        public GunModel(Rigidbody bullet,Transform shotPoint, Transform gun)
        {
            _shotPoint = shotPoint;
            _bullet = bullet;
            _gun = gun;
        }
    }
}