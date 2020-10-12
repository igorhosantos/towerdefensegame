using Assets.Script.view.mainspot;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

namespace Assets.Script.view.enemy
{
    public class EnemyView:MonoBehaviour
    {
        [SerializeField] private EnemyType enemyType;
        [SerializeField] private LifeBar lifeBar;
        [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private AttackView enemyAttack;
        [SerializeField] private float life;
        [SerializeField] private float speed;
        [SerializeField] private float damage;
        [SerializeField] private float attackDelay;
        [SerializeField] private float distanceToAttack;
        

        public EnemyType EnemyType => enemyType;

        private MainSpotView mainSpot;
        private bool enabledToAttack;

        public EnemyView StartEnemy(MainSpotView mainSpot)
        {
            this.mainSpot = mainSpot;
            navMeshAgent.speed = speed;
            navMeshAgent.destination = mainSpot.RectBounds.position;
            lifeBar.SetStatus(life);

            return this;
        }

        void Update()
        {
            if (enabledToAttack) return;

            if (navMeshAgent.remainingDistance <= distanceToAttack)
            {
                navMeshAgent.isStopped = true;
                enabledToAttack = true;
                ActivateAttackLoop();
            }
        }

        private void ActivateAttackLoop()
        {
            Debug.LogWarning("ENABLE TO ATTACK");
            InvokeRepeating(nameof(Attack), attackDelay,attackDelay);
        }

        private void Attack()
        {
            Debug.LogWarning("ATTACK");
            AttackView attack = Instantiate(enemyAttack, transform.position, transform.rotation);
            Vector3 direction = (mainSpot.transform.position - transform.position).normalized;
            attack.ShootDirection(direction, 10f);
        }

        void OnDestroy()
        {
            CancelInvoke(nameof(Attack));
        }

    }
}
