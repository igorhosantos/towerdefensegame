
using Assets.Script.view.statics;
using UnityEngine;

namespace Assets.Script.view.mainspot
{
    public class MainSpotView:MonoBehaviour
    {
        [SerializeField] private LifeBar lifeBar;
        [SerializeField] private Transform rectBounds;
        [SerializeField] private int life;

        public Transform RectBounds => rectBounds;

        void Awake()
        {
            lifeBar.SetStatus(life);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(Gametag.ENEMY_ATTACK))
            {
                Destroy(other.gameObject);
                life -= 10;
                lifeBar.UpdateStatus(life);
            }
        }
    }
}
