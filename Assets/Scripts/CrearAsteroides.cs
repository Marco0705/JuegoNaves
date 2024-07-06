using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearAsteroides : MonoBehaviour
{
    public GameObject[] zonasSpawn;
    public GameObject asteroide;
    protected GameObject asteroideClon;
    public GameObject[] enemigos;
    protected GameObject enemigosClon;
    protected int aleatorioSpawn;
    protected int aleatorioEnemigo;
    protected float increment = 0.0f;
    void Start()
    {
        InvokeRepeating("CrearAsteroide", 0.0f, 2.0f);
    }
    public void CrearAsteroide(){

        aleatorioSpawn = Random.Range(0, zonasSpawn.Length);
        aleatorioEnemigo = Random.Range(0, enemigos.Length);
        asteroideClon = (GameObject) Instantiate(asteroide, zonasSpawn[aleatorioSpawn].gameObject.transform.position, Quaternion.identity);
        enemigosClon = (GameObject) Instantiate(enemigos[aleatorioEnemigo], zonasSpawn[aleatorioSpawn].gameObject.transform.position, Quaternion.identity);
        increment += 0.01f;
        enemigosClon.gameObject.GetComponent<Rigidbody2D>().gravityScale = increment;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
