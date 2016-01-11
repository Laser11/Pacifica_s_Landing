using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayerTally : MonoBehaviour {

    private int P_Fresh;
    private int P_End;
    private int P_Count;

    public bool Friendly;
    private string ID_Fresh = "Fresh";
    private string ID_End = "Finished";
    private string Label;
    Text textbox;

	// Use this for initialization
	void Start () {
        if (Friendly)
        {
            ID_Fresh += "P";
            ID_End += "P";
            Label = "Friendly Units: ";
        }
        else
        {
            ID_Fresh += "E";
            ID_End += "E";
            Label = "Enemy Units: ";
        }
       textbox = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        P_Fresh = GameObject.FindGameObjectsWithTag(ID_Fresh).Length;
        P_End = GameObject.FindGameObjectsWithTag(ID_End).Length;
        P_Count = P_Fresh + P_End;
        P_End = P_Count - P_Fresh;
        textbox.text = Label + P_Fresh + "/" + P_Count;
        
        
	}
}
