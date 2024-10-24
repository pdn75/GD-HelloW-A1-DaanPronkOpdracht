using UnityEngine;
using DynamicBehaviour;

[CreateAssetMenu(fileName = "AddIdleTime", menuName = "ScriptableObjects/Acts/AddIdleTime")]
public class AddIdleTime : Act
{
    public override void PerformAct(Actor p_actor)
    {
        p_actor.AddIdleTime();

        base.PerformAct(p_actor);
    }
}