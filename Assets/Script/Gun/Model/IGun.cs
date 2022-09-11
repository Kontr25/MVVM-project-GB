using UnityEngine;

namespace Script.Gun.Model
{
    public interface IGun
    {
        Transform _shotPoint { get; set; }
        Transform _gun { get; set; }
        Rigidbody _bullet { get; set; }
    }
}