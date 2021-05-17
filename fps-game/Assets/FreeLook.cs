using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FreeLook : MonoBehaviour
{
    float MouseSensitivity = 100f;
    public Transform PlayerBody;
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //To lock cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {   
        //Mouse rotation in X and Y axis


        float mouseX = Input.GetAxis("Mouse X")*MouseSensitivity*Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")*MouseSensitivity*Time.deltaTime;
        PlayerBody.Rotate(Vector3.up*mouseX);
        
        // minus mouseY to prevent inversion
        xRotation -= mouseY;
        
        //Limiting Y axis angles 
        xRotation = Mathf.Clamp( xRotation, -90f, 90f);

        transform.localRotation= Quaternion.Euler(xRotation, 0f, 0f);


    }
}
