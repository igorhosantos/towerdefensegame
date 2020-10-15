using System.Collections.Generic;
using Assets.Script.engine.construction.tower;
using Assets.Script.view.enemy;
using UnityEngine;

namespace Assets.Script.view.construction.tower
{
    public abstract class TowerAttackBehaviour:MonoBehaviour
    {
        [SerializeField] protected AttackView towerAttack;
        [SerializeField] protected TowerView view;
        [SerializeField] protected TowerBehaviourType behaviour;
        [SerializeField] protected float checkDelay = 1f;

        [SerializeField] protected int damageAffected = 1;
        [SerializeField] protected float speedAffected = 0.1f;

        protected List<EnemyView> targets;

        public void StartBehaviour()
        {
            InvokeRepeating(nameof(CheckAttackCondition), 0, checkDelay);
        }

        public void StopBehaviour()
        {
            CancelInvoke(nameof(CheckAttackCondition));
        }

        public abstract void CheckAttackCondition();

        protected void Attack(EnemyView enemy)
        {
            AttackView attack = Instantiate(towerAttack, view.Cannon.position, view.Cannon.rotation);
            Vector3 direction = (enemy.transform.position - view.Cannon.transform.position).normalized;
            attack.ShootDirection(enemy.Speed,direction, damageAffected, speedAffected);
        }
    }
}
