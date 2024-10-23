using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Game : MonoBehaviour
{
    public GameObject parede;
    private GameObject curr_parede;

    // Start is called before the first frame update
    void Start()
    {
        curr_parede = Instantiate(parede);
        parede.transform.position = new Vector3(0.0f, 0.25f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
