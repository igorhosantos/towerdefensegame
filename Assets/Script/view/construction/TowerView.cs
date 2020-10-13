using Assets.Script.view.construction.tower;
using UnityEngine;

namespace Assets.Script.view.construction
{
    public class TowerView:ConstructionView
    {
        [SerializeField] protected Transform cannon;
        [SerializeField] protected TowerAttackBehaviour behaviour;

        public Transform Cannon => cannon;

        protected override void EndGame()
        {
            behaviour.StopBehaviour();
        }

        public override void Place()
        {
            base.Place();
            behaviour.StartBehaviour();
        }

    }
}
