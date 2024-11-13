using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe responsável por gerenciar o comportamento da munição disparada por torres.
public class Municao : MonoBehaviour
{
    public float velocidade = 5f; // Velocidade de movimento da munição.
    private IAtacavel alvo; // Referência ao alvo que será atingido pela munição.
    private int dano; // Quantidade de dano que a munição causará ao atingir o alvo.

    // Método chamado ao criar a munição, configurando o alvo e o dano.
    public void Iniciar(IAtacavel atacavel, int danoDaTorre)
    {
        alvo = atacavel; // Define o alvo da munição.
        dano = danoDaTorre; // Define o dano que será causado ao atingir o alvo.
    }

    // Método chamado a cada frame pelo Unity.
    void Update()
    {
        // Verifica se o alvo ainda existe (não foi destruído ou nulo).
        if (alvo == null || ((MonoBehaviour)alvo) == null)
        {
            Destroy(gameObject); // Destroi a munição se o alvo não existir mais.
            return; // Sai do método para evitar código desnecessário.
        }

        // Obtém a posição do transform do alvo.
        Transform alvoTransform = ((MonoBehaviour)alvo).transform;

        // Move a munição em direção ao alvo, com base na sua velocidade.
        transform.position = Vector2.MoveTowards(
            transform.position,
            alvoTransform.position,
            velocidade * Time.deltaTime
        );

        // Verifica se a munição chegou muito perto do alvo (colisão simulada).
        if (Vector2.Distance(transform.position, alvoTransform.position) < 0.1f)
        {
            alvo.ReceberDano(dano); // Aplica dano ao alvo.
            Destroy(gameObject); // Destroi a munição após atingir o alvo.
        }
    }
}

