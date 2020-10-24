/*
    DESENVOLVIDO PARA O HACKATHON:

        Hackathon Saúde Infantil;

    PELA EQUIPE:

        NOME DOS INTEGRANTES    |   FUNÇÃO  
        1-Matheus Oliveira      |           
        2-                      |           
        3-                      |           
        4-                      |           
        5-                      |   

    DURANTE OS DIAS:

        DD/MM/ANOS até DD/MM/ANOS //FORMATO DIA/MÊS/ANO

    FUNCIONALIDADES DO CÓDIGO:

        + Verificar o as datas;
        + Gerar aleta ao chegar num respectivo dia;

*/
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Unity.IO;
using System;

public class alerta : MonoBehaviour
{
    public Vector3 atual, restante, notifica;
    void Start()
    {

    }

    void Update()
    {
        atual.x = System.DateTime.Now.Day;
        atual.y = System.DateTime.Now.Month;
        atual.z = System.DateTime.Now.Year;

        restante.x = notifica.x - atual.x;
        restante.y = notifica.y - atual.y;
        restante.z = notifica.z - atual.z;
    }



    public class data{
        public int dia,mes,ano,hora,min,seg;
        
    }

}
