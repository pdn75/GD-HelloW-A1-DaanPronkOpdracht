using UnityEngine;
using DynamicBehaviour;

[CreateAssetMenu(fileName = "Die", menuName = "ScriptableObjects/Acts/Die")]
public class Die : Act
{
    public override void PerformAct(Actor p_actor)
    {
        p_actor.isAlive = false;
        p_actor.gameObject.SetActive(false);

        base.PerformAct(p_actor);
    }
}
