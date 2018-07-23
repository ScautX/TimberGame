using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitController : MonoBehaviour {

    public Text HpText;
    public Text WoodText;
    public int Hp = 100;
    public int Wood = 0;

   // Random rnd = new Random();
   // int value = rnd.Next();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        Hp -= 10;
        if(Hp == 0)
        {
            Hp = 100;
            Wood += 10;
        }

        HpText.text = "HP: " + Hp;
        WoodText.text = "Wood: " + Wood;
    }
}
