using UnityEngine;
using System.Collections;
//Note that these are all placeholders
public class P_Behavior : MonoBehaviour {
    public int HLTH;
    public int SPD;
    public int ATT;
    public int DMG;
    bool hit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (hit)
        {
            HLTH -= DMG;
        }
	    if (HLTH <= 0)
        {
            Destroy(gameObject);
        }
	}
    void PathFind ()
    {

    }
}