using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCntr : MonoBehaviour {

  // public BGCntr Tree;//связь скриптов
    public GameObject firstTree;// первое дерево необходимо, чтобы включить коллайдер при открытии сцены
    public bool isDead = false;// говорим, что все живы здоровы 
    public int Wood = 0;
    public int moveSpeed;
    public GameObject deathParticle;
    public bool canBGMove;

    // Use this for initialization
    void Start () {
        firstTree.GetComponent<CapsuleCollider2D>().enabled = true;//включаем первому дерево коллайдер
                                                                   //  bGAnim = backGround.GetComponent<Animation>();
        canBGMove = false;
	}


    public void OnDeath()
    {

        Instantiate(deathParticle, new Vector3(0, -1.6f, 0), Quaternion.identity);
    }

    

    // Update is called once per frame
}
