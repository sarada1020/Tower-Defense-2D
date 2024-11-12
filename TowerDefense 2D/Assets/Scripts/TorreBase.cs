using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TorreBase : MonoBehaviour
{
    public float alcance; // O alcance da torre
    public int dano; // Dano causado
    public Transform spawnPonto; // Ponto de spawn da munição
    public float intervaloDeDisparo = 1.5f; // Tempo entre disparos

    private float contadorDeDisparo = 0f; // Contador para o intervalo de disparo
    protected List<IAtacavel> atacaveisNoAlcance = new List<IAtacavel>();

    void Update()
    {
        AtualizarAlvosNoAlcance(); // Atualiza a lista de alvos dentro do alcance
        contadorDeDisparo -= Time.deltaTime;

        if (atacaveisNoAlcance.Count > 0 && contadorDeDisparo <= 0)
        {
            Atacar(); // Realiza o ataque
            contadorDeDisparo = intervaloDeDisparo;
        }
    }

    protected abstract bool PodeAtacar(IAtacavel atacavel);

    void AtualizarAlvosNoAlcance()
    {
        atacaveisNoAlcance.Clear();
        Collider2D[] alvosDetectados = Physics2D.OverlapCircleAll(transform.position, alcance);

        foreach (Collider2D col in alvosDetectados)
        {
            IAtacavel atacavel = col.GetComponent<IAtacavel>();
            if (atacavel != null && PodeAtacar(atacavel))
            {
                atacaveisNoAlcance.Add(atacavel);
            }
        }
    }

    public abstract void Atacar();

    void OnDrawGizmosSelected() // Para visualizar o alcance no editor
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, alcance);
    }
}
