using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour 
{

    public float scrollSpeed;
    public float tileSizeZ;
    public bool beenset;
    private Vector3 startPosition;
    public GameController gameController;

    void Start () 
    {
        
        startPosition = transform.position;
    }

    void Update ()
    {
        if (gameController.score >= 300)
        {
            scrollSpeed = scrollSpeed + -2;
        }

     
        float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
        
    }
}

