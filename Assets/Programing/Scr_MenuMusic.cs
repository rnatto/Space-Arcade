using UnityEngine;
using System.Collections;
// Use this for initialization

public class Scr_MenuMusic : MonoBehaviour
{
    public GUIStyle estilo;
    public AudioClip music_back;
    public float volume = 1;
    private AudioSource aux;

    void OnGUI()
    {
        GUI.Label(new Rect(100, 250, 100, 20), "RECORDE: " + PlayerPrefs.GetInt("Score"), estilo);
    }
        // Use this for initialization
        void Start()
    {
        aux = gameObject.GetComponent<AudioSource>();
        aux.PlayOneShot(music_back, volume);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
