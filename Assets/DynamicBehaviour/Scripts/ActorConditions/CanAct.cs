using UnityEngine;
using DynamicBehaviour;

[CreateAssetMenu(fileName = "canAct", menuName = "ScriptableObjects/Conditions/CanAct")]
public class CanAct : Condition
{
    public override bool Verify(Actor p_actor)
    {
        return p_actor.canAct;
    }
}