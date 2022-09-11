using System;
using DG.Tweening;
using UnityEngine;

namespace Script.Gun
{
    public class Bullet: MonoBehaviour
    {
        private void Start()
        {
            transform.DOScale(0.01f, 3f);
            Destroy(gameObject, 3.1f);
        }
    }
}