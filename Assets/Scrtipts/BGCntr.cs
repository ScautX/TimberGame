using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCntr : MonoBehaviour {

    public float backbroungSize;
    public float paralaxSpeed;
    public float speed;
    public Camera camera;
    public GameCntr gameCntr;


    private Transform cameraTransform;
    private Transform[] layers;
    private float viewZone = 10;
    private int leftIndex;
    private int rightIndex;
    private float lastCameraX;
    private float deltaX;
    private Transform thisTransform;
    // Use this for initialization
    void Start () {
      //  canIMove = false;

        thisTransform = GetComponent<Transform>();

        cameraTransform = camera.GetComponent<Transform>(); ;
        lastCameraX = cameraTransform.position.x;
        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }

        leftIndex = 0;
        rightIndex = layers.Length - 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone))
            ScrollLeft();
        if (cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewZone))
            ScrollRight();
        if (gameCntr.canBGMove)
        {
            thisTransform.Translate(Vector2.left * Time.deltaTime * speed);
        }
    }

    private void ScrollLeft()
    {
        int lastRight = rightIndex;
        layers[rightIndex].position = Vector2.right * (layers[leftIndex].position.x - backbroungSize);
        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0)
            rightIndex = layers.Length - 1;
    }

    private void ScrollRight()
    {
        int lastLeft = leftIndex;
        layers[leftIndex].position = Vector2.right * (layers[rightIndex].position.x + backbroungSize);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == layers.Length)
            leftIndex = 0;
    }

    

}
