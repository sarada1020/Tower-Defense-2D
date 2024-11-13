using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class GerenciadorDeTorres : MonoBehaviour
{
    // Prefabs das diferentes torres que podem ser instanciadas
    public GameObject torreFracaPrefab;
    public GameObject torreMediaPrefab;
    public GameObject torreFortePrefab;

    // Torre atualmente selecionada para ser colocada no cenário
    private GameObject torreSelecionada;

    // Referência à câmera principal para converter a posição do mouse
    private Camera cameraPrincipal;

    void Start()
    {
        // Obtém a referência à câmera principal
        cameraPrincipal = Camera.main;

        // Inicialmente, nenhuma torre está selecionada
        torreSelecionada = null;
    }

    void Update()
    {
        // Verifica se o botão esquerdo do mouse foi clicado e há uma torre selecionada
        if (Input.GetMouseButtonDown(0) && torreSelecionada != null)
        {
            // Converte a posição do mouse na tela para a posição no mundo
            Vector2 posicaoMouse = cameraPrincipal.ScreenToWorldPoint(Input.mousePosition);

            // Detecta se há um objeto com um colisor na posição do clique
            Collider2D bloco = Physics2D.OverlapPoint(posicaoMouse);

            // Verifica se o colisor encontrado tem a tag "Bloco"
            if (bloco != null && bloco.CompareTag("Bloco"))
            {
                // Obtém o componente TorreExistente do bloco clicado
                TorreExistente torreExistente = bloco.GetComponent<TorreExistente>();

                // Verifica se o bloco pode receber uma torre
                if (torreExistente != null && !torreExistente.TemTorre())
                {
                    // Instancia a torre selecionada na posição do bloco
                    GameObject novaTorre = Instantiate(torreSelecionada, bloco.transform.position, Quaternion.identity);

                    // Associa a nova torre ao bloco
                    torreExistente.DefinirTorre(novaTorre);

                    Debug.Log("Torre posicionada.");
                }
                else
                {
                    // Informa que o bloco já possui uma torre
                    Debug.Log("Já existe uma torre neste local!");
                }
            }
        }
    }

    // Função chamada quando o jogador seleciona a Torre Fraca
    public void SelecionarTorreFraca()
    {
        torreSelecionada = torreFracaPrefab;
        Debug.Log("Torre Fraca selecionada.");
    }

    // Função chamada quando o jogador seleciona a Torre Média
    public void SelecionarTorreMedia()
    {
        torreSelecionada = torreMediaPrefab;
        Debug.Log("Torre Média selecionada.");
    }

    // Função chamada quando o jogador seleciona a Torre Forte
    public void SelecionarTorreForte()
    {
        torreSelecionada = torreFortePrefab;
        Debug.Log("Torre Forte selecionada.");
    }
}

