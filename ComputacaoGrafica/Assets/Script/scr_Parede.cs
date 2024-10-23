using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Parede : MonoBehaviour
{
    public float speed;

    // Distancia para sumir
    public float distancia_sumir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * -speed;

        if (transform.position.z < -distancia_sumir)
        {
            Destroy(gameObject);
        }
    }
}
