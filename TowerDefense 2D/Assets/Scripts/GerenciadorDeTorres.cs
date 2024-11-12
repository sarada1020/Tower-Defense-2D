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
        cameraPrincipal = Camera.main; // Obtem a câmera principal
        torreSelecionada = null;       // Nenhuma torre selecionada no início
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && torreSelecionada != null) // Clique esquerdo
        {
            Vector2 posicaoMouse = cameraPrincipal.ScreenToWorldPoint(Input.mousePosition);
            Collider2D bloco = Physics2D.OverlapPoint(posicaoMouse); // Detecta se clicou em um bloco

            if (bloco != null && bloco.CompareTag("Bloco"))
            {
                // Verifica se já existe uma torre neste bloco
                TorreExistente torreExistente = bloco.GetComponent<TorreExistente>();
                if (torreExistente != null && !torreExistente.TemTorre())
                {
                    // Instancia a torre na posição do bloco
                    GameObject novaTorre = Instantiate(torreSelecionada, bloco.transform.position, Quaternion.identity);
                    torreExistente.DefinirTorre(novaTorre);
                    Debug.Log("Torre posicionada.");
                }
                else
                {
                    Debug.Log("Já existe uma torre neste local!");
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
        Debug.Log("Torre Média selecionada.");
    }

    public void SelecionarTorreForte()
    {
        torreSelecionada = torreFortePrefab;
        Debug.Log("Torre Forte selecionada.");
    }
}

