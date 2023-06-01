using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class path : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float distanceToNearestPointThreshold = 0.02f;

    Vector2 targetPosition = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(targetPosition != Vector2.zero)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }

        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if(hit.collider != null)
            {
                 targetPosition = hit.collider.gameObject.transform.position;
                 Debug.Log ("Target Position: " + hit.collider.gameObject.transform.position);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        SceneManager.LoadScene(1); 
    }
}
