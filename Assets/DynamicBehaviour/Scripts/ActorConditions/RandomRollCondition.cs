using UnityEngine;
using DynamicBehaviour;

[CreateAssetMenu(fileName = "new Condition", menuName = "ScriptableObjects/Conditions/Roll")]
public class RandomRollCondition : Condition
{
    public int outOf;

    public override bool Verify(Actor p_actor)
    {
        int randomNumber = Random.Range(1, outOf);

        if (randomNumber == 1)
            isTrue = true;
        else
            isTrue = false;

        //Debug.Log(isTrue);

        if (inverted)
            return !isTrue;

        return isTrue;
    }
}
