using System;
using Script.Gun.Model;
using UnityEngine;

namespace Script.Gun.ViewModel
{
    public class ViewModelGun : MonoBehaviour, IViewModelGun
    {
        public event Action OnShot;
        public IGun Gun { get; set; }
        public Camera _camera { get; }

        public ViewModelGun(IGun gun, Camera camera)
        {
            this.Gun = gun;
            this._camera = camera;
        }

        public void Shot()
        {
            Rigidbody bullet = Instantiate(Gun._bullet, Gun._shotPoint.position, Quaternion.identity);
            bullet.AddExplosionForce(500f,Gun._gun.transform.position, 50);
            
            OnShot?.Invoke();
        }

        public void GunRotate()
        {
            Vector3 direction = Input.mousePosition - _camera.WorldToScreenPoint(Gun._gun.transform.position);
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Gun._gun.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}