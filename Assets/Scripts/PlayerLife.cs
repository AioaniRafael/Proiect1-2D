using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb; 
    [SerializeField] AudioSource DeathEffect;
    void Start()
    {
        anim=GetComponent<Animator>();
        rb=GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Trap"))
        {
            DeathEffect.Play();
            Die();
        }

        if(collision.gameObject.CompareTag("KillZone"))
        {
            DeathEffect.Play();
            Die();
        }
        
    }
    private void Die()
    {
        
        rb.bodyType=RigidbodyType2D.Static;
        anim.SetTrigger("death");
        
    }
    private void RestartLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
