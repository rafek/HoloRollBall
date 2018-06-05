using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour, IHoldHandler
{
    private bool _addForce = false;

    public void OnHoldCanceled(HoldEventData eventData)
    {
        _addForce = false;
    }

    public void OnHoldCompleted(HoldEventData eventData)
    {
        _addForce = false;
    }

    public void OnHoldStarted(HoldEventData eventData)
    {
        var focusDetails = FocusManager.Instance.GetFocusDetails(GazeManager.Instance);
        var angle = Vector3.Angle(focusDetails.Normal, Vector3.up);

        if (angle <= 15.0f)
        {
            _addForce = true;
        }
    }

    private void Start()
    {
        InputManager.Instance.AddGlobalListener(gameObject);
    }

    private void Update()
    {
        if (_addForce)
        {
            var focusDetails = FocusManager.Instance.GetFocusDetails(GazeManager.Instance);
            var angle = Vector3.Angle(focusDetails.Normal, Vector3.up);

            if (angle <= 15.0f)
            {
                var focusPoint = new Vector3(focusDetails.Point.x, transform.position.y, focusDetails.Point.z);
                var playerPoint = transform.position;

                gameObject.GetComponent<Rigidbody>().AddForce(focusPoint - playerPoint);
            }
        }
    }
}