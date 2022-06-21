using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoDoJogador : MonoBehaviour
{
    public CharacterController oCharacterController;    // referência ao componente 'Character Controller'

    public float velocidadeDoJogador = 12f;             // controla a velocidade de movimento do jogador
    public float gravidade = -19.62f;                   // controla a força da gravidade do jogador
    public float alturaDoPulo = 3f;                     // controla a altura do pulo do jogador

    public Transform verificadorDoChao;                 // referência ao gameObject que verifica se estamos no chão
    public float distanciaDoChao = 0.4f;                // tamanho do raio de checagem de chão
    public LayerMask layerDoChao;                       // referência a 'layer mask' que colocamos no piso

    private Vector3 velocidade;                         // velocidade final que o jogador está se movimentando

    private bool estaNoChao;                            // variável para vermos se o jogador está ou não no chão

    // Update is called once per frame
    void Update()
    {
        // deixa a variável 'estaNoChao' como 'true', caso o jogador esteja encostando no chão
        estaNoChao = Physics.CheckSphere(verificadorDoChao.position, distanciaDoChao, layerDoChao);

        // aplica uma velocidade vertical negativa no jogador para que ele fique no chão
        if(estaNoChao && velocidade.y < 0)
        {
            velocidade.y = -2f;
        }

        // referências aos inputs 'Horizontais' e 'Verticais' do teclado
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // variável responsável por armazenar o movimento do jogador
        Vector3 movimento = transform.right * x + transform.forward * z;
        // movimenta o jogador usando o seu 'Character Controller'
        oCharacterController.Move(movimento * velocidadeDoJogador * Time.deltaTime);

        // faz o jogador pular se estiver no chão ao apertarmos o botão de pulo (barra de espaço)
        if(Input.GetButtonDown("Jump") && estaNoChao)
        {
            velocidade.y = Mathf.Sqrt(alturaDoPulo * -2f * gravidade); 
        }

        // aplica a força da variável 'gravidade' no eixo vertical da variável 'velocidade' (o que nos permite fazer o jogador cair)
        velocidade.y += gravidade * Time.deltaTime;

        // movimenta o 'Character Controller' do jogador com sua velocidade final já calculada
        oCharacterController.Move(velocidade * Time.deltaTime);
    }
}
