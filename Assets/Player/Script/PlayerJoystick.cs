using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] RectTransform lever;
    [SerializeField, Range(10f, 150f)] float leverRange = 30f;
    [SerializeField] Transform player;

    TPSCharacterController tpsCharacterController;
    private Vector2 inputVector;
    private bool isInput;
    private RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        tpsCharacterController = player.GetComponent<TPSCharacterController>();
    }

    void Update()
    {
        if (isInput)
        {
            tpsCharacterController.Move(inputVector);
        }
        else
        {
            inputVector = Vector3.zero;
            tpsCharacterController.Move(inputVector);
        }
    }

    public void ResetLeverPosition()
    {
        lever.transform.localPosition = Vector3.zero;
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
