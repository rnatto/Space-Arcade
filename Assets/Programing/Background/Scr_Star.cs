using UnityEngine;
using System.Collections;

public class Scr_Star : MonoBehaviour {
    public float StarSpeed = 10;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector2(0, -1f * StarSpeed * Time.deltaTime));
        if(transform.position.y < -43.7f)
        {
            transform.position = new Vector2(0, 89.8f);
        }

    }
}
