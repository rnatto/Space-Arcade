using UnityEngine;
using System.Collections;

public class Scr_MusicControl : MonoBehaviour {
    public AudioClip music_shoot;
    public AudioClip music_Explosion;
    public AudioClip music_Back;
    public AudioClip music_Boss;
    public float volume = 1;
    private AudioSource aux;
    private int cond = 0;
    // Use this for initialization
    void Start () {
        aux = gameObject.GetComponent<AudioSource>();
        aux.PlayOneShot(music_Back, volume);
	}
    public void Lazer()
    {
        aux.PlayOneShot(music_shoot,0.05f);
    }
    public void Explosion()
    {
        aux.PlayOneShot(music_Explosion, 0.1f);
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < 10 && cond != 1)
        {
            aux.Stop();
            cond = 1;
            GameObject.Find("Boss_1").GetComponent<Scr_Boss_1>().cond = 1;

            aux.PlayOneShot(music_Boss);
        }
            
	}
}
