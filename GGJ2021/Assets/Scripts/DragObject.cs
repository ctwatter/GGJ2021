using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.InputSystem;

using UnityEngine.EventSystems;



public class DragObject : MonoBehaviour, IPointerEnterHandler, IDragHandler, IPointerDownHandler
{


    private Vector3 mOffset;
    private Vector3 mousePos;
    private float mZCoord;
    private Rigidbody rb;

    void OnMousePos(InputValue value)
    {
        mousePos = value.Get<Vector2>();
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Name: " + eventData.pointerCurrentRaycast.gameObject.name);
        Debug.Log("Tag: " + eventData.pointerCurrentRaycast.gameObject.tag);
        Debug.Log("GameObject: " + eventData.pointerCurrentRaycast.gameObject);
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        mZCoord = Camera.main.WorldToScreenPoint(

            eventData.pointerCurrentRaycast.gameObject.transform.position).z;



        // Store offset = gameobject world pos - mouse world pos

        mOffset = eventData.pointerCurrentRaycast.gameObject.transform.position - GetMouseAsWorldPoint();
        // Debug.Log(mOffset);

    }
    public void OnDrag(PointerEventData eventData)

    {
        if(eventData.pointerCurrentRaycast.gameObject)
        {
            Debug.Log(GetMouseAsWorldPoint());
            rb = eventData.pointerCurrentRaycast.gameObject.GetComponent<Rigidbody>();
            rb.MovePosition(GetMouseAsWorldPoint() + mOffset);
        }


    }




    private Vector3 GetMouseAsWorldPoint()

    {
        // z coordinate of game object on screen
        mousePos.z = mZCoord;

        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePos);

    }

}