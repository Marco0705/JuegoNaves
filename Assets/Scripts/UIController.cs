using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject puntuacion;
    
    void Start()
    {
        General.ncolisiones = 0;
    }

    // Update is called once per frame
    void Update()
    {
        puntuacion.GetComponent<Text>().text = "" + General.ncolisiones.ToString();
    }
    public void Reiniciar(){

        SceneManager.LoadScene("Game");
    }
}
