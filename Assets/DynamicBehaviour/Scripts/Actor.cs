using System.Collections;
using UnityEngine;

namespace DynamicBehaviour
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public abstract class Actor : MonoBehaviour
    {
        [Header("Activities")]
        [SerializeField]
        ScriptableActivityList activities; //list of acts your actor can perform
        [Header("Actor Variables")]
        [HideInInspector]
        public Vector2 startLocation; //where you want the actor to spawn
        [HideInInspector]
        public bool canAct; //keeps track of whether the actor can act or not
        private float idleTime; //used to control isIdle variable
        [SerializeField]
        private float idleDelay; //used to control isIdle variable
        [HideInInspector]
        public bool isIdle; //used to tell if an actor is idle or not, great for idle animations
        [HideInInspector]
        public bool isAlive; //keeps track of if actor is alive or dead
        [HideInInspector]
        public Rigidbody2D rb; //standard Rigidbody2D, required component
        [HideInInspector]
        public Collider2D actorCollider; //standard Collider2D, required component
        [SerializeField]
        private int collisionLayer; //set collision layer of actor in inspector
        private int collisionMask; //creates mask from collisionLayer
        [HideInInspector]
        public Vector2 newVelocity; //used to apply velocity in FixedUpdate()
        public Vector2 maxAccelleration; //limits an actor’s acceleration
        public Vector2 collisionSize; //size for checking collisions

        private void Awake()
        {
            startLocation = transform.position;

            collisionMask = 1 << collisionLayer;
        }

        void OnEnable()
        {
            EnableActor();
        }

        public void EnableActor()
        {
            activities.SortActivities();

            if (rb == null)
                rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;

            if (actorCollider == null)
                actorCollider = GetComponent<Collider2D>();

            ResetActor();
        }

        public void ResetActor()
        {
            isAlive = true;
            canAct = true;
            idleTime = 0;
            isIdle = false;
            transform.position = startLocation;
        }

        public void ActorUpdate()
        {
            foreach (Act activity in activities.list)
            {
                //print(activity.name);
                if (activity == null)
                    continue;

                if (activity.CheckConditions(this))
                {
                    //print(activity.name);
                    activity.PerformAct(this);
                    if (activity.setCanAct)
                    {
                        canAct = false;
                        StartCoroutine(ResetCanAct(activity.resetTime));
                        return;
                    }
                }
            }
        }

        public int GetCollisionMask()
        {
            return collisionMask;
        }

        IEnumerator ResetCanAct(float p_value)
        {
            yield return new WaitForSeconds(p_value);

            canAct = true;
        }
        private IEnumerator resetCanAct;
        public void StartResetCanAct(float p_value)
        {
            resetCanAct = ResetCanAct(p_value);
            StartCoroutine(resetCanAct);
        }

        public void ActorFixedUpdate()
        {
            rb.velocity = new Vector2(
                Mathf.Clamp(rb.velocity.x + newVelocity.x, -maxAccelleration.x, +maxAccelleration.x),
                Mathf.Clamp(rb.velocity.y + newVelocity.y, -maxAccelleration.y, +maxAccelleration.y)
                );
            newVelocity = Vector2.zero;

            rb.gravityScale = rb.velocity.y < -.1f ? 3 : 1;
        }

        public void ResetIdle()
        {
            idleTime = 0;
            isIdle = false;
        }

        public void AddIdleTime()
        {
            idleTime += Time.deltaTime;
            if (idleTime > idleDelay)
            {
                isIdle = true;
                idleTime = 0;
            }
        }

        private void Update()
        {
            ActorUpdate();
        }
        private void FixedUpdate()
        {
            ActorFixedUpdate();
        }
    }
}