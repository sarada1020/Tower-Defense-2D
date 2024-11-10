using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InimigoBase : MonoBehaviour, IAtacavel
{
    public int vida;
    public float velocidade;
    protected int pontoAtual = 0; // Índice do ponto atual no caminho
    protected List<Transform> pontosDoCaminho; // Lista de pontos do caminho

    public void ConfigurarCaminho(List<Transform> caminho)
    {
        pontosDoCaminho = caminho;
    }

    public void Mover()
    {
        if (pontosDoCaminho == null || pontosDoCaminho.Count == 0)
        {
            Debug.LogWarning("Caminho não configurado no inimigo.");
            return;
        }

        if (pontoAtual < pontosDoCaminho.Count)
        {
            Transform pontoDestino = pontosDoCaminho[pontoAtual];
            transform.position = Vector2.MoveTowards(transform.position, pontoDestino.position, velocidade * Time.deltaTime);

            Debug.Log($"Inimigo se movendo para o ponto {pontoAtual}");

            if (Vector2.Distance(transform.position, pontoDestino.position) < 0.1f)
            {
                pontoAtual++;
                Debug.Log($"Inimigo alcançou o ponto {pontoAtual - 1}");
            }
        }
        else
        {
            Debug.Log("Inimigo chegou ao final do caminho.");
            ChegarNoFinalDoCaminho();
        }
    }

    void Update()
    {
        Mover();
    }

    protected abstract void ChegarNoFinalDoCaminho();

    public void ReceberDano(int dano) // Implementação da interface
    {
        vida -= dano;
        if (vida <= 0)
        {
            Destroy(gameObject); // Destroi o inimigo quando a vida é zero
        }
    }
}
