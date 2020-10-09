using UnityEngine;
using UnityEngine.AI;

namespace Assets.Script.view.enemy
{
    public class EnemyView:MonoBehaviour
    {
        [SerializeField] private Transform mainSpot;
        [SerializeField] private LifeBar lifeBar;
        [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private float life;
        [SerializeField] private float speed;


        void Start()
        {
            navMeshAgent.destination = mainSpot.position;
        }
    }
}
