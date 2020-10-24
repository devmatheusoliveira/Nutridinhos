/*

    DESENVOLVIDO PARA O HACKATHON:
    
        Hackathon Saúde Infantil;

    PELA EQUIPE:

        NOME DOS INTEGRANTES    |      FUNÇÃO  
        1-Matheus Oliveira      |   Desenvolvedor        
        2-                      |           
        3-                      |           
        4-                      |           
        5-                      |   

    DURANTE OS DIAS:

        DD/MM/ANOS até DD/MM/ANOS //FORMATO DIA/MÊS/ANO

    FUNCIONALIDADES DO CÓDIGO:

        + Uma caixa de texto(InputField) e um botão para enviar mensagem;
        + Exibir a mensagem enviada;
        + Guardar essa mensagem em um Json;
        + Um bot deverá enviar mensagens automáticas para usuário;
        + Após isso o layout de conversa é fechado
*/

using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Unity.IO;
using UnityEngine.UI;
using TMPro;

public class sistemaDeConversa : MonoBehaviour
{
    public mensagem dialogo;
    int etapa = 0;
    bool etapaFinalizada = false;

    public int alturaTela, LarguraTela;
    public TMP_InputField textoInput;

    //public TextMeshProUGUI mensagemDeTexto;
    void Start()
    {
        while(!etapaFinalizada){
            etapas(etapa);
            etapa++;
            etapas(etapa);
            etapa++;
            etapas(etapa);
            etapa++;
            etapas(etapa);
            etapa++;
            etapas(etapa);
            etapa++;
            etapaFinalizada=true;
        }
    }

    //Funçao de exibição
    void etapas(int etapa){
        switch(etapa){
            case 0:
                MensagemBot("Olá, você poderia me dizer seu nome completo?");
                MensagemUser("Júlia");
                break;
            case 1:
                MensagemBot("Muito bem, Júlia, qual seu peso?");
                MensagemUser("30 Kg");
                break;
            case 2:
                MensagemBot("E sua altura?");
                MensagemUser("1.5 m");
                break;
            case 3:
                MensagemBot("Queria ver seu pratinho, manda uma foto?");
                MensagemUser("Foto");
                break;
            default:
                MensagemBot("Ótimo,você acabou de ganhar 30 moedas");
                break;
        }
    }

    //gerar mensagem bot
    void MensagemBot(string texto){
       print("Bot: " + texto); 
    }

    //gerar mensagem user
    void MensagemUser(string texto){
       print("User: " + texto);
    }

    void Update() {
        alturaTela = Screen.height;
        LarguraTela = Screen.width; 
        dialogo.AjustaTexto();
    }

}
/*
    COISAS UTEIS
    textoInput.placeholder.GetComponent<TextMeshProUGUI>().text = "";


*/
