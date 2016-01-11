using UnityEngine;
using System.Collections;

public class PlayerTally : MonoBehaviour {

    private int P_Fresh;
    private int P_End;
    private int P_Count;
  
    
	// Use this for initialization
	void Start () {

        P_Fresh = GameObject.FindGameObjectsWithTag("FreshP").Length;
       P_Count = P_Fresh;
       
	}
	
	// Update is called once per frame
	void Update () {
        P_Fresh = GameObject.FindGameObjectsWithTag("FreshP").Length;
        P_End = P_Count - P_Fresh;
        Display.
	}
}
