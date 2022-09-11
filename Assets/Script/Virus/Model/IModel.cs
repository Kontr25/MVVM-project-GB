using UnityEngine;

namespace Script.Virus.Model
{
    public interface IModel
    {
        Rigidbody Rigidbody { get; }
        float Speed { get; set; }
        int Health { get; set; }
        GameObject virusObjct { get; set; }
    }
}
