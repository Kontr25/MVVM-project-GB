using System;
using Script.Gun.Model;
using Script.Gun.View;
using Script.Gun.ViewModel;
using UnityEngine;

namespace Script.Gun
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Rigidbody _bulletPrefab;
        [SerializeField] private Transform _shotPoint;
        [SerializeField] private ParticleSystem _shotEffect;
        [SerializeField] private Camera _mainCamera;

        private GunModel _modelGun;
        private ViewModelGun _modelViewGun;
        private GunView _gunView;
        private void Start()
        {
            _gunView = new GunView();
            _modelGun = new GunModel(_bulletPrefab, _shotPoint, transform);
            _modelViewGun = new ViewModelGun(_modelGun, _mainCamera);
            _gunView.Initialize(_modelViewGun, _shotEffect);
        }

        private void Update()
        {
            _modelViewGun.GunRotate();
        }

        public void Shot()
        {
            _modelViewGun.Shot();
        }
    }
}