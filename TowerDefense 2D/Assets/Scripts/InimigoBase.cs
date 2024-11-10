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
        if (pontoAtual < pontosDoCaminho.Count)
        {
            transform.position = Vector2.MoveTowards(transform.position, pontosDoCaminho[pontoAtual].position, velocidade * Time.deltaTime);

            if (Vector2.Distance(transform.position, pontosDoCaminho[pontoAtual].position) < 0.1f)
            {
                pontoAtual++;
            }
        }
        else
        {
            ChegarNoFinalDoCaminho();
        }
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
