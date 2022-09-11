using System;
using Script.Gun.Model;
using Script.Gun.ViewModel;
using UnityEngine;

namespace Script.Gun.View
{
    public class GunView : MonoBehaviour
    {
        private ParticleSystem _shotEffect;

        private IViewModelGun _viewModelGun;
        
        public void Initialize(IViewModelGun viewModelGun, ParticleSystem shotEffect)
        {
            _viewModelGun = viewModelGun;
            _shotEffect = shotEffect;
            _viewModelGun.OnShot += OnShot;
        }

        private void OnShot()
        {
            _shotEffect.Play();
        }

        private void OnDestroy()
        {
            _viewModelGun.OnShot -= OnShot;
        }
    }
}