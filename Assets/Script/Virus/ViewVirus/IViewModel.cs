using System;
using Script.Virus.Model;
using UnityEngine;

namespace Script.Virus.ViewVirus
{
    public interface IViewModel
    {
        IModel Model { get; }

        event Action<int> OnDamaged;

        VictoryEventManager VictoryEventManager { get; }

        int remainingHealth { get; set; }
        void Damage(int hp);
        void Death();
        void Move(Rigidbody rigidbody, float speed);
    }
}