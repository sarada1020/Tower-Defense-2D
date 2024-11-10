using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Municao : MonoBehaviour
{
    public float velocidade = 5f;
    private IAtacavel alvo;
    private int dano;

    public void Iniciar(IAtacavel atacavel, int danoDaTorre)
    {
        alvo = atacavel;
        dano = danoDaTorre;
    }

    void Update()
    {
        if (alvo == null || ((MonoBehaviour)alvo) == null) // Verifica se o alvo foi destruído
        {
            Destroy(gameObject);
            return;
        }

        Transform alvoTransform = ((MonoBehaviour)alvo).transform;
        transform.position = Vector2.MoveTowards(transform.position, alvoTransform.position, velocidade * Time.deltaTime);

        if (Vector2.Distance(transform.position, alvoTransform.position) < 0.1f)
        {
            alvo.ReceberDano(dano);
            Destroy(gameObject);
        }
    }
}

