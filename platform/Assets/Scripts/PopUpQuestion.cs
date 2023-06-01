using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpQuestion : MonoBehaviour

{
 [SerializeField]private GameObject question1;
    // Start is called before the first frame update
    void Start()
    {
        question1.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            question1.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
