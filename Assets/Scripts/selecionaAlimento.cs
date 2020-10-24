using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selecionaAlimento : MonoBehaviour
{
    public alimentos[] inNatura;
    public alimentos[] processados;
    public alimentos[] ultraProcessados;
    public alimentos[] industrializados;
    public alimentos[] saudaveis;
    public alimentos[] barraDeAlimentos;

    private Touch primeiroToque;
    public Vector2 startPos;
    public Vector2 direction;

    public Text m_Text;
    string message;
    public int dirx, diry, pivo;
    
    public Transform recebeInstanciados;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            switch (touch.phase)
            {
                case TouchPhase.Began:
                
                    startPos = touch.position;
                    message = "Begun ";
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
                    if((startPos.y < Screen.height*0.1f) && (direction.y > Screen.height*0.1f)){
                        diry = 1;
                    }
                    break;
                case TouchPhase.Ended:
                    pivo += dirx;
                    pivo = RestringeArray(pivo, barraDeAlimentos.Length);
                    recebeInstanciados.localPosition = new Vector3((pivo - (barraDeAlimentos.Length/2))*3, 3.27f, 0);
                    dirx = 0;
                    message = "Ending";
                    break;
            }
        }
    }
    void Start() {
        pivo = barraDeAlimentos.Length/2;
        barraDeAlimentos = sorteiaAlimentos(inNatura, processados, ultraProcessados, 10);
        for (int i = 0; i < barraDeAlimentos.Length; i++)
        {
            Instantiate(barraDeAlimentos[i].prefab, new Vector3((i - (barraDeAlimentos.Length/2))*3, 3.27f, 0), Quaternion.identity, recebeInstanciados);
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

    alimentos[] sorteiaAlimentos( alimentos[] inNatura, alimentos[] processados, alimentos[] ultraProcessados, int tamanhoArray){
        List<alimentos> teste = new List<alimentos>();

        for(int i = 0; i < tamanhoArray; i++){
            alimentos testes = new alimentos();
            switch(Random.Range(-1,2)){
                case -1:
                    testes = saudaveis[Random.Range(0,saudaveis.Length)];
                    break;
                case 0:
                    testes = saudaveis[Random.Range(0,saudaveis.Length)];
                    break;
                case 1:
                    testes = industrializados[Random.Range(0,industrializados.Length)];
                    break;
                case 2:
                    testes = industrializados[Random.Range(0,industrializados.Length)];
                    break;
                default:
                    break;
            }
            teste.Add(testes);
        }

        return teste.ToArray();
    }

    [System.Serializable]
    public class alimentos{
        public string tag;
        public GameObject prefab;
        public int pontos;
        
    }
}
