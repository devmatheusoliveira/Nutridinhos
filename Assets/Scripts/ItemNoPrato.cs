using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemNoPrato : MonoBehaviour
{
    public GameObject objetoSelecionado;
    
    public GameObject smileFeliz;
    public GameObject smileTriste;

    public alimentos[] inNatura;
    public alimentos[] ultraProcessados;

    public float cronometro;


    public Text scoreText;
    public int score;
    
    void Start()
    {
        smileFeliz.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        smileTriste.gameObject.GetComponent<SpriteRenderer>().enabled = false;        
    }

    void Update()
    {
        if(objetoSelecionado != null){
            foreach(alimentos alimento in inNatura){
                if(objetoSelecionado.tag == alimento.tag()){
                    score += alimento.pontos;
                    smileFeliz.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    cronometro = 0;
                    Destroy(objetoSelecionado);                
                }
            }
            foreach(alimentos alimento in ultraProcessados){
                if(objetoSelecionado.tag == alimento.tag()){
                    score += alimento.pontos;
                    smileTriste.gameObject.GetComponent<SpriteRenderer>().enabled = true; 
                    cronometro = 0;                
                    Destroy(objetoSelecionado);
                }
            }
        }else{
            if(contador(2)){
                smileFeliz.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                smileTriste.gameObject.GetComponent<SpriteRenderer>().enabled = false; 
            }
        }
        
        scoreText.text = score.ToString();

        
    }

    bool contador(float tempo){
        cronometro += Time.deltaTime;
        if(cronometro > tempo){
            return true;
        }else{
            return false;
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        objetoSelecionado = other.gameObject;
    }

}
