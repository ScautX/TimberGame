using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StumpCntr : MonoBehaviour {

    public GameCntr GameCntr;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameCntr.isDead) transform.Translate(GameCntr.moveSpeed * Vector2.left * Time.deltaTime);// двигаемся вправо, пока флаг isDead = true

        if (transform.position.x < -12) Destroy(this.gameObject);// уничтожаем себя при выходе за сцену 
	}
}
