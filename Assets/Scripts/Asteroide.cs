using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asteroide : MonoBehaviour
{
    public GameObject explosion;
    protected GameObject explosionClon;
    //public GameObject puntos;

    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.tag == "Laser"){

            General.ncolisiones = General.ncolisiones +1;
            explosionClon = (GameObject) Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(explosionClon.gameObject, 2.0f);
            Destroy(other.gameObject);
            Destroy(this.gameObject); 

        }
    }
}
