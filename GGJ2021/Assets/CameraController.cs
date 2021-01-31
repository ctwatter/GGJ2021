using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraController : MonoBehaviour
{

    public float moveValue;
    public Vector3 rotationVec;
    public float rotateSpeed = 75f;
    public float moveSpeed = 10f;
    bool stopmoving = false;
    public Volume volume;

    public GameObject GlassesUI;

    

    private void Update() {
        if(!stopmoving)
        {
            transform.Rotate(rotationVec * rotateSpeed * Time.deltaTime);
        
            transform.position += (transform.rotation * transform.forward * moveValue * moveSpeed * Time.deltaTime);
        }
        
        
    }

    void OnCameraForward(InputValue value)
    {
        moveValue = value.Get<float>();
    }

    void OnCameraRotation(InputValue value)
    {
        var inputValue = value.Get<Vector2>();
        rotationVec = new Vector3(inputValue.y, inputValue.x, 0);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.transform.tag == "Gmawall")
        {
            DepthOfField DepthOfField;
            if(volume.profile.TryGet(out DepthOfField)){
                DepthOfField.mode.value = DepthOfFieldMode.Off;
            }
            
            stopmoving = true;
            Debug.Log("COLLIDE");

            //trigger glasses animation -> transition to new scene
            //trigger sound
            GlassesUI.GetComponent<Animator>().SetTrigger("fall");
        }
        
    }
}
