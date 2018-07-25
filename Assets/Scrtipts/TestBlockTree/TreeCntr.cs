using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCntr : MonoBehaviour {

    public bool isBroken = false;
    private GameObject[] blocksArr;
    private int quantityBlocks;
    private int actualBlock = 1;
    private Random rnd = new Random();
    private float position = -5f;
    public GameObject Block;
    public GameObject Crone;
    public GameObject Roots;

    // Use this for initialization
    void Start () {
        quantityBlocks = Random.Range(1, 10)+2 ;
        blocksArr = new GameObject[quantityBlocks];
        blocksArr[0] = Instantiate(Roots, new Vector3(0, position), Quaternion.identity);

        for (int i = 1; i < quantityBlocks - 1; i++)
        {
            position += 1.5f;
            blocksArr[i]= Instantiate(Block, new Vector3(0, position), Quaternion.identity);
        }

        position += 1.5f;

        blocksArr[quantityBlocks-1] = Instantiate(Crone , new Vector3( 0, position), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
