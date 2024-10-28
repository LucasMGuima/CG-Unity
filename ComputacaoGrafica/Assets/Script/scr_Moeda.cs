using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Moeda : MonoBehaviour
{
    public float rotate_speed = 5.0f;
    public float speed = 0.05f;

    // Distancia para sumir
    public float distancia_sumir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, 0.0f, rotate_speed);

        transform.position += new Vector3(0.0f, 0.0f, 1.0f) * -speed;

        if (transform.position.z < -distancia_sumir)
        {
            Destroy(gameObject);
        }
    }
}
