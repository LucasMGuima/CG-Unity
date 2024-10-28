using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_Player : MonoBehaviour
{
    // Movimento
    public float speed;
    public float rotate_speed;
    public float jump_force;
    public bool can_jump;

    public TextMeshProUGUI scoreText;

    // Camera
    public Camera camera;

    // Rigbody
    public Rigidbody rigidbody;

    // Pontuação
    private float timer;
    private int score;
    public float score_distance; // De quanto em quanto de distancia percorrida o jogador pontua
    private float last_time;

    // Start is called before the first frame update
    void Start()
    {
        can_jump = true;
        last_time = Time.deltaTime;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion new_rotation = Quaternion.identity;

        // Rotaciona para esquerda e a direita
        if (Input.GetKey(KeyCode.A)){
            new_rotation = Quaternion.Euler(transform.rotation.x, -25.0f, transform.rotation.z);
            transform.position += new Vector3(-speed, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            new_rotation = Quaternion.Euler(transform.rotation.x, 25.0f, transform.rotation.z);
            transform.position += new Vector3(speed, 0.0f, 0.0f);
        }

        transform.rotation = new_rotation;

        // Pulo
        if (Input.GetKeyDown(KeyCode.Space) && can_jump)
        {
            rigidbody.AddForce(0.0f, jump_force, 0.0f);
            can_jump = false;
        }

        // Movimenta para a frente
        //transform.position += transform.forward * speed;

        // Atualiza a poisção da camera
        camera.transform.position = transform.position + new Vector3(0.0f, 1.9f, -3.0f);

        // Checa se pontuo
        checkScore();
        scoreText.text = $"{score}";

        // Caiu
        if(transform.position.y < 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    // Checa se percorreu a distancia para pontuar
    void checkScore()
    {
        timer += Time.deltaTime;
        if (timer >= 10)
        {
            score += 1;
            timer = 0;
        }
    }

    // Trata a colisão
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Inimigo")
        {
            SceneManager.LoadScene("GameOver");
        }

        if(collision.collider.tag == "Solido")
        {
            can_jump = true;
        }
    }
}
