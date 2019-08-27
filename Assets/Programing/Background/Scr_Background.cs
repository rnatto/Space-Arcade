using UnityEngine;
using System.Collections;

public class Scr_Background : MonoBehaviour {
    public float BackgroundSpeed = 2;
    void Start () {
	
	}
	void Update () {
        transform.Translate(new Vector2(0, -0.1f * BackgroundSpeed * Time.deltaTime));
	}
}
