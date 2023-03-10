using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCollector : MonoBehaviour
{
    private int PineApple=0;
    [SerializeField] private Text PineAppleText;
    [SerializeField] private AudioSource Collect;
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("PineApple")) 
        {
            Collect.Play();
            Destroy(collision.gameObject);
            PineApple++;
            PineAppleText.text="PineApple: "+ PineApple;
        }   
    }
}
