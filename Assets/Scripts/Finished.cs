using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finished : MonoBehaviour
{
    [SerializeField] private AudioSource FinishEffect;
    private bool lvlcompleted=false;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(!lvlcompleted)
        {
            FinishEffect.Play();    
            Invoke("CompleteLevel",2f);
            lvlcompleted=true;
        }
        
        
    }
    private void CompleteLevel()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

}
