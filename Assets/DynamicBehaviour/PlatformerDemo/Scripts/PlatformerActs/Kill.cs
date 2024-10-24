using UnityEngine;
using DynamicBehaviour;

namespace PlatformerDemo
{
    [CreateAssetMenu(fileName = "Kill", menuName = "ScriptableObjects/Acts/Kill")]
    public class Kill : Act
    {
        public float distance;
        public int layer;

        public override void PerformAct(Actor p_actor)
        {
            PlatformerActor actor = p_actor as PlatformerActor;
            if (actor == null)
                return;

            int layerMask = 1 << layer;
            Actor target = null;
            RaycastHit2D hit;

            if (actor.GetFacing() > 0)
            {
                //actor = p_actor.actorCollider.IsTouchingLayers(mask,out hit);
                if (Physics2D.Raycast(p_actor.transform.position, Vector2.right, distance, layerMask))
                {
                    hit = Physics2D.Raycast(p_actor.transform.position, Vector2.right, distance, layerMask);
                    target = hit.collider.gameObject.GetComponent<Actor>();
                }
                //if (Physics2D.Raycast(p_actor.transform.position, Vector2.right, distance, layerMask, out hit))
                /*if (hit.collider.gameObject.GetComponent<Actor>() != null
                    &&hit.collider.gameObject.GetComponent<Actor>() != null)*/
            }
            else if (actor.GetFacing() < 0)
            {
                if (Physics2D.Raycast(p_actor.transform.position, Vector2.left, distance, layerMask))
                {
                    hit = Physics2D.Raycast(p_actor.transform.position, Vector2.left, distance, layerMask);
                    target = hit.collider.gameObject.GetComponent<Actor>();
                }
                //if (hit.collider.gameObject.GetComponent<Actor>() != null)
            }
            if (target == null)
                return;
            target.isAlive = false;
            target.gameObject.SetActive(false);

            base.PerformAct(p_actor);
        }
    }
}