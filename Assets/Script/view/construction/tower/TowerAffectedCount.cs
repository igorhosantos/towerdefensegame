using System.Collections.Generic;
using Assets.Script.view.enemy;
using Assets.Script.view.statics;
using UnityEngine;

namespace Assets.Script.view.construction.tower
{
    public class TowerAffectedCount:TowerAttackBehaviour
    {
        [SerializeField] protected int maxTargets;
        public override void CheckAttackCondition()
        {
            GameObject[] possibleTargets = GameObject.FindGameObjectsWithTag(Gametag.ENEMY);
            targets = new List<EnemyView>();

            foreach (var t in possibleTargets)
            {
                EnemyView enemy = t.GetComponent<EnemyView>();
                if (!targets.Contains(enemy) && targets.Count < maxTargets)
                    targets.Add(enemy);
            }

            if (targets.Count > 0) targets.ForEach(Attack);
        }

    }
}
