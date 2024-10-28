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
        float x_scale = Random.Range(5, 10);
        float y_scale = Random.Range(1, 3);
        transform.localScale = new Vector3(x_scale, y_scale, 0.5f);
        transform.position = new Vector3(transform.position.x, y_scale/2, transform.position.z);
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
