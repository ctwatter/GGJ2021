using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class avoidMouse : MonoBehaviour
{
    Vector2 mousePosition;
    public int distanceToRunAway;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(gameObject.transform.position, mousePosition) < distanceToRunAway)
        {
            Vector2 direciton = ((Vector2)gameObject.transform.position - mousePosition).normalized;
            float knockbackAmount = .1f;
            gameObject.transform.Translate(direciton * knockbackAmount);
        }
    }

    void OnMousePos(InputValue value)
    {
        mousePosition = Camera.main.ScreenToWorldPoint(value.Get<Vector2>());
    }

    void OnMouseClick()
    {
        if(Vector2.Distance(mousePosition, gameObject.transform.position) < 1)
        {
            PersitentData.Instance.NextScene();
        }
    }
}
