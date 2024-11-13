using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe abstrata que serve como base para inimigos no jogo
// Implementa a interface IAtacavel, garantindo que inimigos podem receber dano
public abstract class InimigoBase : MonoBehaviour, IAtacavel
{
    public int vida; // Quantidade de vida do inimigo
    public float velocidade; // Velocidade de movimento do inimigo
    protected int pontoAtual = 0; // Índice do ponto atual no caminho que o inimigo está seguindo
    protected List<Transform> pontosDoCaminho; // Lista de pontos que definem o caminho do inimigo

    // Método para configurar o caminho que o inimigo deve seguir
    public void ConfigurarCaminho(List<Transform> caminho)
    {
        pontosDoCaminho = caminho; // Define o caminho a partir de uma lista de transformações
    }

    // Método responsável por mover o inimigo ao longo dos pontos do caminho
    public void Mover()
    {
        // Verifica se o caminho foi configurado e possui pontos
        if (pontosDoCaminho == null || pontosDoCaminho.Count == 0)
        {
            Debug.LogWarning("Caminho não configurado no inimigo."); // Alerta no console caso o caminho não esteja configurado
            return;
        }

        // Verifica se o inimigo ainda não chegou ao final do caminho
        if (pontoAtual < pontosDoCaminho.Count)
        {
            // Obtém o ponto de destino atual
            Transform pontoDestino = pontosDoCaminho[pontoAtual];

            // Move o inimigo em direção ao ponto de destino
            transform.position = Vector2.MoveTowards(transform.position, pontoDestino.position, velocidade * Time.deltaTime);

            // Mensagem de depuração para verificar o movimento
            Debug.Log($"Inimigo se movendo para o ponto {pontoAtual}");

            // Verifica se o inimigo alcançou o ponto de destino
            if (Vector2.Distance(transform.position, pontoDestino.position) < 0.1f)
            {
                pontoAtual++; // Atualiza para o próximo ponto
                Debug.Log($"Inimigo alcançou o ponto {pontoAtual - 1}"); // Mensagem de depuração ao alcançar o ponto
            }
        }
        else
        {
            // Quando o inimigo chega ao final do caminho
            Debug.Log("Inimigo chegou ao final do caminho.");
            ChegarNoFinalDoCaminho(); // Chama o método abstrato para definir o que acontece ao final do caminho
        }
    }

    // Chamado automaticamente a cada frame para realizar o movimento
    void Update()
    {
        Mover(); // Atualiza o movimento do inimigo
    }

    // Método abstrato a ser implementado nas classes derivadas
    // Define o que acontece quando o inimigo chega ao final do caminho
    protected abstract void ChegarNoFinalDoCaminho();

    // Implementação da interface IAtacavel
    // Método chamado quando o inimigo recebe dano
    public void ReceberDano(int dano)
    {
        vida -= dano; // Reduz a vida do inimigo
        if (vida <= 0)
        {
            Destroy(gameObject); // Destroi o objeto inimigo quando sua vida chega a zero
        }
    }
}

