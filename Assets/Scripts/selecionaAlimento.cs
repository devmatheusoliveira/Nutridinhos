using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selecionaAlimento : MonoBehaviour
{
    public alimentos[] inNatura;
    public alimentos[] ultraProcessados;
    public alimentos[] barraDeAlimentos;

    private Touch primeiroToque;
    public Vector2 startPos;
    public Vector2 direction;
    public int dirx, diry, pivo;

    public bool enviarComida;

    public bool moveuToque, soltouTela;

    public GameObject objetoSelecionado; 

    public Text scoreText;
     
    
    public Transform recebeInstanciados;

    private Vector3 target;

    public int score;

    void Start() {
        barraDeAlimentos = sorteiaAlimentos(inNatura, ultraProcessados, 10);
        for (int i = 0; i < barraDeAlimentos.Length; i++)
        {
            Instantiate(barraDeAlimentos[i].prefab, new Vector3((i + 1 - (barraDeAlimentos.Length/2))*3, 3.27f, -1.5f), Quaternion.identity, recebeInstanciados);
        }
        pivo = barraDeAlimentos.Length/2+1;
        soltouTela = true;


    }
    void Update()
    {
        ReconheceToques();
        
        if(enviarComida){/*
            foreach(alimentos alimento in inNatura){
                if(objetoSelecionado.tag == alimento.tag()){
                    score += alimento.pontos;
                }
            }
            foreach(alimentos alimento in ultraProcessados){
                if(objetoSelecionado.tag == alimento.tag()){
                    score += alimento.pontos;
                }
            }
            Destroy(objetoSelecionado);*/
            scoreText.text = "enviando...";
            enviarComida=false;
        }
        

        if(soltouTela){
            pivo += dirx;
            dirx = 0;
            pivo = RestringeArray(pivo, barraDeAlimentos.Length);
            target = new Vector3((pivo - (barraDeAlimentos.Length/2))*3, 3.27f, -1.5f);
            moveBarra(pivo);
        }
    }

    void ReconheceToques(){

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                
                    startPos = touch.position;
                    break;

                case TouchPhase.Moved:
                    direction = touch.position - startPos;
                    if(Mathf.Abs(direction.x) > Screen.width*0.25f){    
                        if(direction.x > 0){
                            dirx = 1;
                        }else{
                            dirx = -1;
                        }
                    }
                    if((direction.y > Screen.height*0.1f)){
                        enviarComida = true;
                    }
                    moveuToque = true;
                    break;
                case TouchPhase.Ended:
                    soltouTela = true;
                    break;
            }
        }
    }
    
    void moveBarra( int pivo){
        float step =  25 * Time.deltaTime;
        if(Mathf.Abs(recebeInstanciados.position.x - target.x) > 0){
            recebeInstanciados.position = Vector3.MoveTowards(recebeInstanciados.position, target, step);
        }else{
            soltouTela=false;
        }
       
       
    }

    int RestringeArray(int pivo, int tamanhoDoArray){
        if(pivo >= tamanhoDoArray-1){
            return tamanhoDoArray-1;
        }
        if(pivo <= 0){
            return 0;
        }
        return pivo;
    }

    alimentos[] sorteiaAlimentos( alimentos[] inNatura, alimentos[] ultraProcessados, int tamanhoArray){
        List<alimentos> ListaDeAlimentos = new List<alimentos>();

        for(int i = 0; i < tamanhoArray; i++){
            alimentos novosAlimentos = new alimentos();
            switch(Random.Range(-1,2)){
                case -1:
                    novosAlimentos = inNatura[Random.Range(0,inNatura.Length)];
                    break;
                case 0:
                    novosAlimentos = inNatura[Random.Range(0,inNatura.Length)];
                    break;
                case 1:
                    novosAlimentos = ultraProcessados[Random.Range(0,ultraProcessados.Length)];
                    break;
                case 2:
                    novosAlimentos = ultraProcessados[Random.Range(0,ultraProcessados.Length)];
                    break;
                default:
                    break;
            }
            ListaDeAlimentos.Add(novosAlimentos);
        }

        return ListaDeAlimentos.ToArray();
    }

    void OnTriggerEnter(Collider other)
    {
        objetoSelecionado = other.gameObject;
    }

    [System.Serializable]
    public class alimentos{
        public GameObject prefab;
        public int pontos;

        public string tag(){
            return prefab.tag;
        }
    }
}
