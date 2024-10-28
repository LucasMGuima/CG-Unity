using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Game : MonoBehaviour
{
    public GameObject parede;

    public float max_x;
    public float min_x;

    public float spawn_time = 60.0f; // Tempo em segundos entre os spawns

    private GameObject curr_parede;
    private float timer;
    

    // Start is called before the first frame update
    void Start()
    {
        timer = spawn_time;

        GerarNovaParede();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            GerarNovaParede();
            timer = spawn_time;
        }
    }

    void GerarNovaParede()
    {
        // Pega o tamanho da parede
        float scale = parede.transform.localScale.x;

        // Acha uma nova posição em x para a parede
        float x_pos = Random.Range(max_x-scale/2, min_x+scale/2);

        // Cria uma nova parede
        curr_parede = Instantiate(parede);
        curr_parede.transform.position = new Vector3(x_pos, 0.5f, 0.0f) + transform.position;
    }
}
