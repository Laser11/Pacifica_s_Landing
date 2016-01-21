using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour {

    //determines control sensitivity
    public int Sensitivity;
    public int ZoomSensitivity;
    public int rotationSensitivity;
    //indicates max zoom
    public float zoomCeiling;
    public float zoomFloor;
    //indicates max pitch
    public float pitchCeiling;
    public float pitchFloor;

    private float speed;
    private float VrotationAmount;
	private Vector3 rotation;
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
        speed = Sensitivity * Time.deltaTime;
        VrotationAmount = rotationSensitivity * 5 * Time.deltaTime;
        if (Input.GetKey("w") || mPosY >= Screen.height)//up
        {

            //transforms in reference to the world; X is forwards and backwards, Z is right and left
            transform.Translate(0, 0, speed, Space.World);
        }
        //ditto for A,S, and D
        if (Input.GetKey("s") || mPosY <= 0)//down
        {
            transform.Translate(0, 0, -speed, Space.World);
        }
        if (Input.GetKey("d") || mPosX >= Screen.width)//right
        {
            transform.Translate(speed, 0, 0, Space.World);
        }
        if (Input.GetKey("a") || mPosX <= 0)//left
        {
            transform.Translate(-speed, 0, 0, Space.World);
        }
        
        //controls the pitch of the camera; be careful setting limits near 90 and 0
        if (Input.GetKey("q") && rotation.x > pitchCeiling)
        {
			rotation.x -= VrotationAmount;
        }
		if (Input.GetKey("e") && rotation.x < pitchFloor)
        {
			rotation.x += VrotationAmount;
        }
		this.transform.localRotation = Quaternion.Euler(rotation);
    }
    
    //controls camera zoom/elevation
    void CameraZoom(float mPosZ)
    {
        if ( (transform.position.y <=zoomCeiling && mPosZ<0) || (transform.position.y>zoomFloor &&mPosZ>0))
        {
        transform.Translate(0, 0, mPosZ * ZoomSensitivity);
        }
    }

}
