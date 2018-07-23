using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StumpMover : MonoBehaviour {

    public HitController Tree;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

      if (Tree.isDead)
        {
            transform.Translate(-8 * Time.deltaTime, 0,0);
        }

      if (transform.position.x <= -12)
        {
            Tree.isDead = false;
            transform.position = new Vector3(0, 0, 0);
        }

    }
}
