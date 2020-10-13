
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
            AttackView currentAttack = other.GetComponent<AttackView>();
            Destroy(other.gameObject);
            life += -currentAttack.DamageAffected;
            lifeBar.UpdateStatus(-currentAttack.DamageAffected);

            if (life == 0) NotifyMainSpotDied?.Invoke();
        }
    }
}
