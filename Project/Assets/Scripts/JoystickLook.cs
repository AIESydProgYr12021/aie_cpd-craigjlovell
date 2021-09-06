using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickLook : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private float joystickVisualDistance = 50;
    private Image containter;
    private Image joystick;

    Vector3 direction;
    public Vector3 Direction { get { return direction; } }

    public bool showCon = true;
    private bool isConShowing = true;

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
        Vector2 pos = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(containter.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / containter.rectTransform.sizeDelta.x);
            pos.y = (pos.y / containter.rectTransform.sizeDelta.y);

            Vector2 refPivot = new Vector2(0.5f, 0.5f);
            Vector2 p = containter.rectTransform.pivot;
            pos.x += p.x - 0.5f;
            pos.y += p.y - 0.5f;

            float x = Mathf.Clamp(pos.x, -1, 1);
            float y = Mathf.Clamp(pos.y, -1, 1);

            direction = new Vector3(x, y, 0).normalized;
            Debug.Log(direction);

            joystick.rectTransform.anchoredPosition = new Vector3(x * joystickVisualDistance, y * joystickVisualDistance);
        }
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        direction = default(Vector3);
        joystick.rectTransform.anchoredPosition = default(Vector3);
    }

    // Update is called once per frameS
    void Update()
    {
        if (showCon != isConShowing)
        {
            containter.enabled = showCon;
            joystick.enabled = showCon;
            isConShowing = showCon;
        }

        if (syncJoyStickInput && !isDragging)
        {
            direction = new Vector2(Input.GetAxis("HozX"), Input.GetAxis("VertY"));
            joystick.rectTransform.anchoredPosition = new Vector3(direction.x * joystickVisualDistance, direction.y * joystickVisualDistance, 0);
        }
    }
}
