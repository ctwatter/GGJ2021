using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class avoidMouse : MonoBehaviour
{
    Vector2 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        // mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(gameObject.transform.position, mousePosition) < 10)
        {
            Vector2 direciton = ((Vector2)gameObject.transform.position - mousePosition).normalized;
            int knockbackAmount = 2;
            gameObject.transform.Translate(direciton * knockbackAmount);
        }
    }

    void OnMousePosition(InputValue value)
    {
        mousePosition = value.Get<Vector2>();
    }
}
