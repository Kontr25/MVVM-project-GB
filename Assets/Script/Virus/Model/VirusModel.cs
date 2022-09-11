using UnityEngine;

namespace Script.Virus.Model
{
    public class VirusModel : MonoBehaviour, IModel
    {
        public Rigidbody Rigidbody { get; }
        public float Speed { get; set; }
        public int Health { get; set; }
        public GameObject virusObjct { get; set; }
        public VirusModel(Rigidbody rigidbody, float speed, int health, GameObject objetVirus)
        {
            Rigidbody = rigidbody;
            Speed = speed;
            Health = health;
            virusObjct = objetVirus;
        }
    }
}