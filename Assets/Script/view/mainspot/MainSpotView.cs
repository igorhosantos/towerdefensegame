
using System.Collections.Generic;
using Assets.Script.view.common;
using Assets.Script.view.statics;
using UnityEngine;

namespace Assets.Script.view.mainspot
{
    public class MainSpotView:CharacterView
    {
        [SerializeField] private Transform rectBounds;
        
        public Transform RectBounds => rectBounds;

        public delegate void MainSpotEvent();
        public static event MainSpotEvent NotifyMainSpotDied;

        protected override List<string> DamageTags => new List<string>{Gametag.ENEMY_ATTACK};

        protected override void OnDamage(GameObject other)
        {
            switch (other.tag)
            {
                case Gametag.ENEMY_ATTACK:

                    Destroy(other.gameObject);
                    life += -10;
                    lifeBar.UpdateStatus(-10);

                    if (life == 0)
                    {
                        NotifyMainSpotDied?.Invoke();
                    }
                    break;
            }
        }
    }
}
