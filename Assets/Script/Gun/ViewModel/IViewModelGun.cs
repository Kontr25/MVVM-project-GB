using System;
using Script.Gun.Model;
using UnityEngine;

namespace Script.Gun.ViewModel
{
    public interface IViewModelGun
    {
        event Action OnShot;
        IGun Gun { get; }
        Camera _camera { get; }
        void Shot();
    }
}