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
        Vector3 focusPoint;
        _addForce = Utils.IsFloorPointed(out focusPoint);
    }

    private void Start()
    {
        InputManager.Instance.AddGlobalListener(gameObject);
    }

    private void Update()
    {
        if (_addForce)
        {
            Vector3 focusPoint;

            if (Utils.IsFloorPointed(out focusPoint))
            {
                var focusPointNorm = new Vector3(focusPoint.x, transform.position.y, focusPoint.z);
                var playerPoint = transform.position;

                gameObject.GetComponent<Rigidbody>().AddForce(focusPointNorm - playerPoint);
            }
        }
    }
}