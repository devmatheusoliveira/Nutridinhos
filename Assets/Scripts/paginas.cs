using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class paginas : MonoBehaviour
{
    public Button teste;
    public string scenename;
    public Canvas canvas;
    void Update()
    {
        teste.onClick.AddListener(carregaCena);
        
    }
    void carregaCena()
    {
        canvas.enabled = false;
    }
}
