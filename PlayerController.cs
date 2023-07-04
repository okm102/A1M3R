using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform character;   //the camera placed within the character model will now move with the character
    float verticalLookRotation;             //verticle rotation of the camera 
    public float mouseSensitivity = 100f;   //sensitivity
    void Update()   
    {
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X"));             //Camera will act with the mouse movement
        verticalLookRotation -= Input.GetAxisRaw("Mouse Y");
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);    //Maximum range of rotation must be added to avoid the camera turning infinitely 
        character.localEulerAngles = new Vector3(verticalLookRotation, 0, 0);   //X,Y,Z rotation values are converted to the quaternion's format

    }

    void Start()
    {
        Cursor.visible = false;                     //the cursor is hidden using boolean
        Cursor.lockState = CursorLockMode.Locked;   //cursor is locked at the centre of the screen where the crosshair game object is placed

    }
}