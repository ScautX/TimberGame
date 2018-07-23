using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitController : MonoBehaviour {    

    public Text HpText;
    public Text WoodText;
    public int Hp = 100;
    public int Wood = 0;

    public bool isDead = false;


   // Random rnd = new Random();
   // int value = rnd.Next();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

       if(isDead)
        {
            transform.Translate(-8 * Time.deltaTime, 0, 0);
            
        }
        else
        {
            if (transform.position.x > 0) transform.position = new Vector3(0, 0, 0);
        }
		
	}

    void OnMouseDown()
    {
        Hp -= 10;
        if(Hp == 0)
        {
            Hp = 100;
            Wood += 10;
            
            transform.position = new Vector3(12,0,0);

            isDead = true;
        }

        HpText.text = "HP: " + Hp;
        WoodText.text = "Wood: " + Wood;


    }
}
