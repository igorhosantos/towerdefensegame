using UnityEngine;

namespace Assets.Script.view.construction
{
    public class BuildingStatus:MonoBehaviour
    {
        [SerializeField] private Color AvailableColor;
        [SerializeField] private Color UnavailableColor;
        [SerializeField] private Renderer renderer;

        public void UpdateStatus(bool isEnableToBuild)
        {
            renderer.material.color = isEnableToBuild ? AvailableColor : UnavailableColor;
        }
    }
}
