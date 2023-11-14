using UnityEngine;
using UnityEngine.EventSystems;

public class CameraJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] RectTransform lever;
    [SerializeField, Range(10f, 150f)] float leverRange = 30f;
    [SerializeField] Transform cameraTransform;

    TPSCharacterController tpsCharacterController;
    private Vector2 inputVector;
    private bool isInput;
    private RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        tpsCharacterController = cameraTransform.GetComponentInParent<TPSCharacterController>();
    }

    void Update()
    {
        if (isInput)
        {
            tpsCharacterController.LookAround(inputVector);
        }
        else
        {
            inputVector = Vector3.zero;
            tpsCharacterController.LookAround(inputVector);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);
        isInput = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);
    }

    public void ControlJoystickLever(PointerEventData eventData)
    {
        var inputDir = eventData.position - rectTransform.anchoredPosition;

        var clampedDir = inputDir.magnitude < leverRange ? inputDir
            : inputDir.normalized * leverRange;

        lever.anchoredPosition = clampedDir;

        inputVector = clampedDir / leverRange;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        lever.anchoredPosition = Vector2.zero;
        isInput = false;
    }
}
