using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Player : MonoBehaviour
{
    // Movimento
    public float speed;
    public float rotate_speed;
    public float jump_force;

    // Camera
    public Camera camera;

    // Rigbody
    public Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotaciona para esquerda e a direita
        if (Input.GetKey(KeyCode.A)){
            transform.Rotate(0.0f, -rotate_speed, 0.0f);
        }
        if (Input.GetKey(KeyCode.D)){
            transform.Rotate(0.0f, rotate_speed, 0.0f);
        }

        // Pulo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(0.0f, jump_force, 0.0f);
        }

        // Movimenta para a frente
        transform.position += transform.forward * speed;

        // Atualiza a poisção da camera
        camera.transform.position = transform.position + new Vector3(0.0f, 1.9f, -3.0f);
    }


    // Trata a colisão
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Inimigo")
        {
            Debug.Log("Colisão com inimigo");
        }
    }
}
