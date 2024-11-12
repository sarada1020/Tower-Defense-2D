using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeTorres : MonoBehaviour
{
    public GameObject torreFracaPrefab;
    public GameObject torreMediaPrefab;
    public GameObject torreFortePrefab;

    private GameObject torreSelecionada;
    private Camera cameraPrincipal;

    void Start()
    {
        cameraPrincipal = Camera.main; // Obtem a c�mera principal
        torreSelecionada = null;       // Nenhuma torre selecionada no in�cio
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && torreSelecionada != null) // Clique esquerdo
        {
            Vector2 posicaoMouse = cameraPrincipal.ScreenToWorldPoint(Input.mousePosition);
            Collider2D bloco = Physics2D.OverlapPoint(posicaoMouse); // Detecta se clicou em um bloco

            if (bloco != null && bloco.CompareTag("Bloco"))
            {
                // Verifica se j� existe uma torre neste bloco
                TorreExistente torreExistente = bloco.GetComponent<TorreExistente>();
                if (torreExistente != null && !torreExistente.TemTorre())
                {
                    // Instancia a torre na posi��o do bloco
                    GameObject novaTorre = Instantiate(torreSelecionada, bloco.transform.position, Quaternion.identity);
                    torreExistente.DefinirTorre(novaTorre);
                    Debug.Log("Torre posicionada.");
                }
                else
                {
                    Debug.Log("J� existe uma torre neste local!");
                }
            }
        }
    }

    public void SelecionarTorreFraca()
    {
        torreSelecionada = torreFracaPrefab;
        Debug.Log("Torre Fraca selecionada.");
    }

    public void SelecionarTorreMedia()
    {
        torreSelecionada = torreMediaPrefab;
        Debug.Log("Torre M�dia selecionada.");
    }

    public void SelecionarTorreForte()
    {
        torreSelecionada = torreFortePrefab;
        Debug.Log("Torre Forte selecionada.");
    }
}

