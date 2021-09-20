using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VirtualJoyStickMain : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private float joystickVisualDistance = 80;
    private Image containter;
    private Image joystick;

    public Vector2 Direction { get; private set; }

    public bool syncJoyStickInput = true;
    private bool isDragging = false;

    private void Start()
    {
        var imgs = GetComponentsInChildren<Image>();
        containter = imgs[0];
        joystick = imgs[1];
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        isDragging = true;
        Vector2 pos = Vector2.zero;
        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(containter.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            return;
        }
        pos.x /= containter.rectTransform.sizeDelta.x;
        pos.y /= containter.rectTransform.sizeDelta.y;

        Vector2 p = containter.rectTransform.pivot;
        pos.x += p.x - 0.5f;
        pos.y += p.y - 0.5f;

        pos.x = Mathf.Clamp(pos.x, -1, 1);
        pos.y = Mathf.Clamp(pos.y, -1, 1);

        Direction = pos;
        Debug.Log(Direction.normalized);

        joystick.rectTransform.anchoredPosition = new Vector3(pos.x * joystickVisualDistance, pos.y * joystickVisualDistance, 0);
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
        Direction = Vector2.zero;
        joystick.rectTransform.anchoredPosition = Vector3.zero;
    }

    // Update is called once per frameS
    void Update()
    {
        if(syncJoyStickInput && !isDragging)
        {
            Direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            joystick.rectTransform.anchoredPosition = new Vector3(Direction.x * joystickVisualDistance, Direction.y * joystickVisualDistance, 0);         
        }
    }
}
