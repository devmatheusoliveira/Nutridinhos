using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI; 
using UnityEngine;
using TMPro;


[System.Serializable]
public class mensagem
{
        public bool IsUser;
        public GameObject pivo;
        public TextMeshProUGUI texto;
        public Image background;
        public string conteudo;
        public Vector2 tamanhoDoTexto;

        public void AjustaTexto(){
            /*if(conteudo.ToCharArray().Length > 46){
                
            }
            texto.text = conteudo;
            tamanhoDoTexto.x = conteudo.ToCharArray().Length * 37 + 60;
            tamanhoDoTexto.y = texto.GetComponent<RectTransform>().rect.height;
            background.GetComponent<RectTransform>().sizeDelta = tamanhoDoTexto;
            */
        }
        void criarMensagem(GameObject pivo, string conteudo, TextMeshPro texto, Image background, Vector2 position){
            
        }

}

/*
    [TextArea(3,10)]
    public string[] frases;

*/
