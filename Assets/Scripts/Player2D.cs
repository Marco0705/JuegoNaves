using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2D : MonoBehaviour
{
    public GameObject laser;
    private GameObject laserClonD;
    private GameObject laserClonI;
    public GameObject puntoSpawnD;
    public GameObject puntoSpawnI;
    public float fuerzaLaser = 10.0f;
    public VariableJoystick vj;
    private float h;
    private float v;
    public float velocidadAvion = 5.0f;
    public GameObject explosion;
    protected GameObject explosionClon;
    protected bool bloquearDerecha = false;
    protected bool bloquearIzquierda = false;
    protected bool bloquearAbajo = false;
    protected bool bloquearArriba = false;
    public GameObject puntuacion;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        h = vj.Horizontal * Time.deltaTime * velocidadAvion;
        v = vj.Vertical * Time.deltaTime * velocidadAvion;

        if(h > 0.0f){

            if(!bloquearDerecha){
                
                this.gameObject.transform.Translate(h, 0.0f, 0.0f);
            }
            
        }
        if(h < 0.0f){

            if(!bloquearIzquierda){

                this.gameObject.transform.Translate(h, 0.0f, 0.0f);
            }  
        }
        if(v < 0.0f){

            if(!bloquearAbajo){

                this.gameObject.transform.Translate(0.0f, v, 0.0f);
            }  
        }
        if(v > 0.0f){

            if(!bloquearArriba){

                this.gameObject.transform.Translate(0.0f, v, 0.0f);
            }  
        }
        

        if(Input.GetMouseButtonDown(1)){

            laserClonI = (GameObject)Instantiate(laser, puntoSpawnI.gameObject.transform.position, Quaternion.identity);
            laserClonI.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, fuerzaLaser);

            laserClonD = (GameObject)Instantiate(laser, puntoSpawnD.gameObject.transform.position, Quaternion.identity);
            laserClonD.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, fuerzaLaser);

        }
    }
    private void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.tag == "Asteroid"){

            General.ncolisiones = General.ncolisiones +1;

            explosionClon = (GameObject) Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(explosionClon.gameObject, 2.0f);
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "LimiteDerecho"){

            bloquearDerecha = true;
        }
        if(other.gameObject.tag == "LimiteIzquierdo"){

            bloquearIzquierda = true;
        }
        if(other.gameObject.tag == "LimiteInferior"){

            bloquearAbajo = true;
        }
        if(other.gameObject.tag == "LimiteSuperior"){

            bloquearArriba = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other){

        if(other.gameObject.tag == "LimiteDerecho"){

            bloquearDerecha = false;
        }
        if(other.gameObject.tag == "LimiteIzquierdo"){

            bloquearIzquierda = false;
        }
        if(other.gameObject.tag == "LimiteInferior"){

            bloquearAbajo = false;
        }
        if(other.gameObject.tag == "LimiteSuperior"){

            bloquearArriba = false;
        }

    }
}
