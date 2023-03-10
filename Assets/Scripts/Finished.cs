using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finished : MonoBehaviour
{
    [SerializeField] private AudioSource FinishEffect;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        FinishEffect.Play();    
        CompleteLevel();
    }
    private void CompleteLevel()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

}
