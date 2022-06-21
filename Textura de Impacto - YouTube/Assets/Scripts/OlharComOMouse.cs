using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlharComOMouse : MonoBehaviour
{   
    public float sensibilidadeDoMouse = 200f;               // controla o quão sensível o movimento do mouse é no jogo
    public Transform corpoDoJogador;                        // referência ao gameObject pai do jogador (o que contém esse gameObject como filho)
    float rotacaoX = 0f;                                    // controla a rotação horizontal da câmera
    
    // Start is called before the first frame update
    void Start()
    {
        // trava o cursor do mouse no centro da tela
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // referências aos inputs 'Horizontais' e 'Verticais' vindos do mouse
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadeDoMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadeDoMouse * Time.deltaTime;

        // calcula a rotação do mouse e a limita para que não giremos mais que 180°
        rotacaoX -= mouseY;
        rotacaoX = Mathf.Clamp(rotacaoX, -90f, 90f);

        // aplica essa rotação na nossa câmera
        transform.localRotation = Quaternion.Euler(rotacaoX, 0f, 0f);

        // rotaciona o corpo do jogador (o gameObject pai)
        corpoDoJogador.Rotate(Vector3.up * mouseX);
    }
}
