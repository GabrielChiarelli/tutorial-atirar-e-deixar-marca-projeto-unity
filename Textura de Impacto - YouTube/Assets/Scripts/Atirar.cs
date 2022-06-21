using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour
{  
    // variável que serve de referência a 'imagem de impacto'
    public GameObject imagemDeImpacto;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // roda o método 'AtirarProjetil()'
        AtirarProjetil();
    }

    private void AtirarProjetil()
    {
        // verifica se apertamos o botão esquerdo do mouse
        if(Input.GetButtonDown("Fire1"))
        {
            // variável que lança um raio invisível do centro da tela
            Ray raio = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

            // variável para identificarmos no que foi que o raio bateu
            RaycastHit hit;

            // verifica se o raio bateu em algum gameObject
            if(Physics.Raycast(raio, out hit, float.PositiveInfinity))
            {
                // spawna nossa 'imagem de impacto' no local que o raio atingiu, utilizando também sua rotação
                Instantiate(imagemDeImpacto, hit.point + (hit.normal * 0.01f), Quaternion.FromToRotation(Vector3.up, hit.normal));
            }
        }
    }
}
