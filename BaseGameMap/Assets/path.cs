using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class path : MonoBehaviour
{
     
     [SerializeField] Transform [] Points;
     [SerializeField] private float moveSpeed;
     [SerializeField] private float distanceToNearestPointThreshold = 0.02f;

     private int pointsIndex;

     Vector2 targetPosition = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = Points[pointsIndex].transform.position;
        Debug.Log("Current index: "+pointsIndex);

    }

    // Update is called once per frame
    void Update()
    {
        if(targetPosition != Vector2.zero)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        // if(pointsIndex <= Points.Length -1)
        // {
        //     var targetPosition = Points[pointsIndex].transform.position;
        //     transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        //     // if(transform.position == Points[pointsIndex].transform.position)
        //     if (Vector2.Distance(transform.position, Points[pointsIndex].transform.position) < distanceToNearestPointThreshold)
        //     {
        //         pointsIndex += 1;
        //         Debug.Log("Current index: "+pointsIndex);
        //     }
        // }
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
}
