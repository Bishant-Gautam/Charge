using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] Transform[] Points;
    int startPoint;
    [SerializeField] float moveSpeed;

    int i;
    private void Start()
    {
        transform.position = Points[startPoint].position;
    }
    // Update is called once per frame
    void Update()
    {
        //This is setting platform a and b 
        if (Vector2.Distance(transform.position, Points[i].position) < 0.01f)
        {
            i++;
            if (i == Points.Length)
            {
                i = 0;
            }
        }
        // This line of code is to move the platform left and right
        transform.position = Vector2.MoveTowards(transform.position, Points[i].position, moveSpeed * Time.deltaTime);
    }
}
