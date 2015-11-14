using UnityEngine;
using System.Collections;

public class LelftClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = new RaycastHit();
            Ray rayClick = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(rayClick, out hit))
            { 
                //activate drop down menu?
            }

	}
}
