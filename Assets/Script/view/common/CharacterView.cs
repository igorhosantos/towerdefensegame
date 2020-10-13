
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.view.common
{
    [RequireComponent(typeof(Collider))]
    public abstract class CharacterView:MonoBehaviour
    {
        [SerializeField] protected LifeBar lifeBar;
        [SerializeField] protected int life;
        protected abstract List<string> DamageTags { get; } 
        protected abstract void OnDamage(GameObject other);

        protected virtual void Awake()
        {
            lifeBar.SetStatus(life);
        }

        void OnTriggerEnter(Collider other)
        {
            if (DamageTags.Contains(other.gameObject.tag))
            {
               OnDamage(other.gameObject);
            }
        }
    }
}
