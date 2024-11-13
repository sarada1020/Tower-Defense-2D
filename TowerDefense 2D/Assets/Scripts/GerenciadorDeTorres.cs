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

    // Torre atualmente selecionada para ser colocada no cen�rio
    private GameObject torreSelecionada;

    // Refer�ncia � c�mera principal para converter a posi��o do mouse
    private Camera cameraPrincipal;

    void Start()
    {
        // Obt�m a refer�ncia � c�mera principal
        cameraPrincipal = Camera.main;

        // Inicialmente, nenhuma torre est� selecionada
        torreSelecionada = null;
    }

    void Update()
    {
        // Verifica se o bot�o esquerdo do mouse foi clicado e h� uma torre selecionada
        if (Input.GetMouseButtonDown(0) && torreSelecionada != null)
        {
            // Converte a posi��o do mouse na tela para a posi��o no mundo
            Vector2 posicaoMouse = cameraPrincipal.ScreenToWorldPoint(Input.mousePosition);

            // Detecta se h� um objeto com um colisor na posi��o do clique
            Collider2D bloco = Physics2D.OverlapPoint(posicaoMouse);

            // Verifica se o colisor encontrado tem a tag "Bloco"
            if (bloco != null && bloco.CompareTag("Bloco"))
            {
                // Obt�m o componente TorreExistente do bloco clicado
                TorreExistente torreExistente = bloco.GetComponent<TorreExistente>();

                // Verifica se o bloco pode receber uma torre
                if (torreExistente != null && !torreExistente.TemTorre())
                {
                    // Instancia a torre selecionada na posi��o do bloco
                    GameObject novaTorre = Instantiate(torreSelecionada, bloco.transform.position, Quaternion.identity);

                    // Associa a nova torre ao bloco
                    torreExistente.DefinirTorre(novaTorre);

                    Debug.Log("Torre posicionada.");
                }
                else
                {
                    // Informa que o bloco j� possui uma torre
                    Debug.Log("J� existe uma torre neste local!");
                }
            }
        }
    }

    // Fun��o chamada quando o jogador seleciona a Torre Fraca
    public void SelecionarTorreFraca()
    {
        torreSelecionada = torreFracaPrefab;
        Debug.Log("Torre Fraca selecionada.");
    }

    // Fun��o chamada quando o jogador seleciona a Torre M�dia
    public void SelecionarTorreMedia()
    {
        torreSelecionada = torreMediaPrefab;
        Debug.Log("Torre M�dia selecionada.");
    }

    // Fun��o chamada quando o jogador seleciona a Torre Forte
    public void SelecionarTorreForte()
    {
        torreSelecionada = torreFortePrefab;
        Debug.Log("Torre Forte selecionada.");
    }
}

