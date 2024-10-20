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

    // Pontuação
    private int score;
    public float score_distance; // De quanto em quanto de distancia percorrida o jogador pontua
    private Vector3 lest_pos_checked;

    // Start is called before the first frame update
    void Start()
    {
        lest_pos_checked = transform.position;
        score = 0;
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

        // Checa se pontuo
        checkScore();
        Debug.Log($"Score: {score}");
    }

    // Checa se percorreu a distancia para pontuar
    void checkScore()
    {
        Vector3 curr_pos = transform.position;
        if((curr_pos.z - lest_pos_checked.z) >= score_distance)
        {
            lest_pos_checked = transform.position;
            score += 1;
        }
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
