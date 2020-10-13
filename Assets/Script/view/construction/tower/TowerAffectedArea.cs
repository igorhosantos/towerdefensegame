using System.Collections.Generic;
using Assets.Script.view.enemy;
using Assets.Script.view.statics;
using UnityEngine;

namespace Assets.Script.view.construction.tower
{
    public class TowerAffectedArea:TowerAttackBehaviour
    {
        [SerializeField] protected float rangeArea = 15f;
        public override void CheckAttackCondition()
        {
            GameObject[] possibleTargets = GameObject.FindGameObjectsWithTag(Gametag.ENEMY);
            float shortestDistance = Mathf.Infinity;

            targets = new List<EnemyView>();

            foreach (var t in possibleTargets)
            {
                float distance = Vector3.Distance(transform.position, t.transform.position);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    EnemyView enemy = t.GetComponent<EnemyView>();
                    if (!targets.Contains(enemy) && shortestDistance <= rangeArea)
                        targets.Add(enemy);
                }

            }

            if (targets.Count > 0) targets.ForEach(Attack);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, rangeArea);
        }

    }
}
