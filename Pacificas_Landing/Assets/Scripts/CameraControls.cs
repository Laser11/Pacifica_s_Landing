using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour {

    //determines control sensitivity
    public int Sensitivity;
    public int ZoomSensitivity;
    //indicates max zoom
    public float zoomCeiling;

    private float speed;
 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float MouseX = Input.mousePosition.x;
        float MouseY = Input.mousePosition.y;
        float MouseZ = Input.GetAxis("Mouse ScrollWheel");
        KeyMove(MouseX, MouseY);
        CameraZoom(MouseZ);
        
	}

    /// <summary>
    /// controls WASD camera movements
    /// </summary>
    void KeyMove(float mPosX, float mPosY)
    {

        if (Input.GetKey("w") || mPosY >= Screen.height)//up
        {
            speed = Sensitivity * Time.deltaTime;
            //transforms in reference to the world; X is forwards and backwards, Z is right and left
            transform.Translate(0, 0, speed, Space.World);
        }
        //ditto for A,S, and D
        if (Input.GetKey("s") || mPosY <= 0)//down
        {
            speed = Sensitivity * Time.deltaTime;
            transform.Translate(0, 0, -speed, Space.World);
        }
        if (Input.GetKey("d") || mPosX >= Screen.width)//right
        {
            speed = Sensitivity * Time.deltaTime;
            transform.Translate(speed, 0, 0, Space.World);
        }
        if (Input.GetKey("a") || mPosX <= 0)//left
        {
            speed = Sensitivity * Time.deltaTime;
            transform.Translate(-speed, 0, 0, Space.World);
        }
    }
    void CameraZoom(float mPosZ)
    {
        if ( (transform.position.y <=zoomCeiling && mPosZ<0) || (transform.position.y >0 &&mPosZ>0))
        {
        transform.Translate(0, 0, mPosZ * ZoomSensitivity);
        }
    }
}
