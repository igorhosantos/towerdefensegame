
using System.Collections.Generic;
using Assets.Script.engine.construction.tower;
using Assets.Script.view.enemy;
using Assets.Script.view.statics;
using UnityEngine;

namespace Assets.Script.view.construction
{
    public class TowerView:ConstructionView
    {
        [SerializeField] protected AttackView constructionAttack;
        [SerializeField] protected Transform cannon;
        [SerializeField] protected TowerBehaviourType behaviour;
        [SerializeField] protected float rangeArea = 15f;
        [SerializeField] protected float checkDelay = 1f;


        private List<EnemyView> targets;

        protected override void Start()
        {
            base.Start();
            InvokeRepeating(nameof(CheckTarget),0,checkDelay);
        }

        private void CheckTarget()
        {
            if (!Placed) return;

            GameObject[] possibleTargets = GameObject.FindGameObjectsWithTag(Gametag.ENEMY);
            targets = new List<EnemyView>();

            foreach (var t in possibleTargets)
            {
                EnemyView enemy = t.GetComponent<EnemyView>();
                if (!targets.Contains(enemy))
                    targets.Add(enemy);
            }

            if (targets.Count > 0) targets.ForEach(Attack);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position,rangeArea);
        }

        private void Attack(EnemyView enemy)
        {
            AttackView attack = Instantiate(constructionAttack, cannon.position, cannon.rotation);
            Vector3 direction = (enemy.transform.position - cannon.transform.position).normalized;
            attack.ShootDirection(direction, 10f);
        }

    }
}
