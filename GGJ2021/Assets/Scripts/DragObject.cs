using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.InputSystem;



public class DragObject : MonoBehaviour
{

    private Vector3 mOffset;
    private Vector3 mousePos;
    private float mZCoord;

    void OnMousePosition(InputValue value)
    {
        mousePos= value.Get<Vector2>();
        
    }

    void OnMouseDown()

    {

        mZCoord = Camera.main.WorldToScreenPoint(

            gameObject.transform.position).z;



        // Store offset = gameobject world pos - mouse world pos

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

    }


    private Vector3 GetMouseAsWorldPoint()

    {
        // z coordinate of game object on screen
        mousePos.z = mZCoord;

        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePos);

    }

    void OnMouseDrag()

    {

        transform.position = GetMouseAsWorldPoint() + mOffset;

    }

}