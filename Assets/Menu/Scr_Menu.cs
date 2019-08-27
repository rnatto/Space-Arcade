using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scr_Menu : MonoBehaviour{
    private AudioSource aux; 
    void OnMouseDown()
    {
        if (name == "START")
        {
            aux = gameObject.GetComponent<AudioSource>();
            aux.Stop();
            SceneManager.LoadScene(1);
        }
        else
            Application.Quit();
    }
}   
