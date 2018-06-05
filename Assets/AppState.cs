using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.SpatialMapping;
using UnityEngine;

public class AppState : MonoBehaviour, IInputClickHandler
{
    public GameObject TargetPrefab;
    public GameObject PlayerPrefab;
    public Material OcclusionMaterial;
    public int TargetCount;

    private bool _targetsPlaced = false;
    private bool _playerPlaced = false;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (!_targetsPlaced)
        {
            var focusDetails = FocusManager.Instance.GetFocusDetails(GazeManager.Instance);
            var angle = Vector3.Angle(focusDetails.Normal, Vector3.up);

            if (angle <= 15.0f)
            {
                Instantiate(TargetPrefab, focusDetails.Point, Quaternion.identity);

                TargetCount = TargetCount - 1;
            }

            _targetsPlaced = TargetCount == 0;

            if (_targetsPlaced)
            {
                SurfaceMeshesToPlanes.Instance.MakePlanes();
            }

        }
        else if (!_playerPlaced)
        {
            var focusDetails = FocusManager.Instance.GetFocusDetails(GazeManager.Instance);
            var angle = Vector3.Angle(focusDetails.Normal, Vector3.up);

            if (angle <= 15.0f)
            {
                Instantiate(PlayerPrefab, focusDetails.Point + Vector3.up * .3f, Quaternion.identity);

                _playerPlaced = true;

                SpatialMappingManager.Instance.SetSurfaceMaterial(OcclusionMaterial);

                InputManager.Instance.RemoveGlobalListener(gameObject);
            }
        }

        eventData.Use();
    }

    private void Start()
    {
        InputManager.Instance.AddGlobalListener(gameObject);
    }
}
