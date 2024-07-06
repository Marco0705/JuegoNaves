using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tierra : MonoBehaviour
{
    public GameObject explosion;
    protected GameObject explosionClon;
    public GameObject panelPerder;
    void Start()
    {
        
    }
    void Update()
    {
        Time.timeScale = 1.0f;
    }
    public void Detener(){

        Time.timeScale = 0.0f;
        Destroy(this.gameObject);

    }
    private void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.tag == "Asteroid"){

            panelPerder.SetActive(true);
            explosionClon = (GameObject)Instantiate(explosion, other.gameObject.transform.position, Quaternion.identity);
            Destroy(explosionClon.gameObject, 3.0f);
            Destroy(other.gameObject);
            Invoke("Detener", 0.5f);
            
        }
    }
}
