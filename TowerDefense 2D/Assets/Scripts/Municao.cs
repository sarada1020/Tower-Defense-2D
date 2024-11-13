using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe respons�vel por gerenciar o comportamento da muni��o disparada por torres.
public class Municao : MonoBehaviour
{
    public float velocidade = 5f; // Velocidade de movimento da muni��o.
    private IAtacavel alvo; // Refer�ncia ao alvo que ser� atingido pela muni��o.
    private int dano; // Quantidade de dano que a muni��o causar� ao atingir o alvo.

    // M�todo chamado ao criar a muni��o, configurando o alvo e o dano.
    public void Iniciar(IAtacavel atacavel, int danoDaTorre)
    {
        alvo = atacavel; // Define o alvo da muni��o.
        dano = danoDaTorre; // Define o dano que ser� causado ao atingir o alvo.
    }

    // M�todo chamado a cada frame pelo Unity.
    void Update()
    {
        // Verifica se o alvo ainda existe (n�o foi destru�do ou nulo).
        if (alvo == null || ((MonoBehaviour)alvo) == null)
        {
            Destroy(gameObject); // Destroi a muni��o se o alvo n�o existir mais.
            return; // Sai do m�todo para evitar c�digo desnecess�rio.
        }

        // Obt�m a posi��o do transform do alvo.
        Transform alvoTransform = ((MonoBehaviour)alvo).transform;

        // Move a muni��o em dire��o ao alvo, com base na sua velocidade.
        transform.position = Vector2.MoveTowards(
            transform.position,
            alvoTransform.position,
            velocidade * Time.deltaTime
        );

        // Verifica se a muni��o chegou muito perto do alvo (colis�o simulada).
        if (Vector2.Distance(transform.position, alvoTransform.position) < 0.1f)
        {
            alvo.ReceberDano(dano); // Aplica dano ao alvo.
            Destroy(gameObject); // Destroi a muni��o ap�s atingir o alvo.
        }
    }
}

