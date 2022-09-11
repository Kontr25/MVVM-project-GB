using System;
using Script.Virus.Model;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script.Virus.ViewVirus
{
    public class ViewModelVirus : MonoBehaviour, IViewModel
    {
        public IModel Model { get; }
        public event Action<int> OnDamaged;
        public VictoryEventManager VictoryEventManager { get; }
        public int remainingHealth { get; set; }
        
        public ViewModelVirus(IModel model, VictoryEventManager victoryEventManager)
        {
            Model = model;
            VictoryEventManager = victoryEventManager;
        }

        public void Damage(int hp)
        {
            Model.Health -= hp;
            remainingHealth = Model.Health;
            
            OnDamaged?.Invoke(Model.Health);
            if (remainingHealth <= 0) Death();
        }

        public void Death()
        {
            VictoryEventManager.Victory.Invoke();
            Destroy(Model.virusObjct,0.1f);
        }

        public void Move(Rigidbody rigidbody, float speed)
        {
            Vector3 diretion = new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2));
            rigidbody.velocity = diretion * speed * Time.deltaTime;
            rigidbody.angularVelocity = diretion * speed;
        }
    }
}