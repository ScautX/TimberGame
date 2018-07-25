using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCntr : MonoBehaviour {

    public TreeCntr TreeCntr;
    public int Hp = 3;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        Hp -= 1;
        if (Hp == 0)
        {
            TreeCntr.isBroken = true;
            Destroy(this.gameObject);
        }
    }

}
