
using UnityEngine;

namespace Assets.Script.view.construction
{
    public class BuildingStatus:MonoBehaviour
    {
        [SerializeField] private Renderer renderer;

        public void UpdateStatus(bool isEnableToBuild)
        {
            renderer.material.color = isEnableToBuild ? Color.green : Color.red;
        }
    }
}
