using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Uma classe base abstrata para torres no jogo.
// Esta classe define comportamentos comuns e propriedades compartilhadas entre diferentes tipos de torres.
public abstract class TorreBase : MonoBehaviour
{
    public float alcance; // O alcance da torre, determinando até onde ela pode detectar inimigos.
    public int dano; // O dano causado pela torre ao atacar.
    public Transform spawnPonto; // O ponto de spawn da munição (onde os tiros ou projéteis serão gerados).
    public float intervaloDeDisparo = 1.5f; // Tempo (em segundos) entre cada ataque da torre.

    private float contadorDeDisparo = 0f; // Um contador usado para controlar o intervalo de disparo.
    protected List<IAtacavel> atacaveisNoAlcance = new List<IAtacavel>();
    // Lista de objetos que podem ser atacados e estão dentro do alcance.

    // Método chamado a cada frame pelo Unity.
    void Update()
    {
        AtualizarAlvosNoAlcance(); // Atualiza a lista de alvos dentro do alcance da torre.
        contadorDeDisparo -= Time.deltaTime; // Reduz o contador de disparo conforme o tempo passa.

        // Se houver alvos no alcance e o intervalo de disparo tiver terminado:
        if (atacaveisNoAlcance.Count > 0 && contadorDeDisparo <= 0)
        {
            Atacar(); // Realiza o ataque (implementado nas subclasses).
            contadorDeDisparo = intervaloDeDisparo; // Reinicia o contador para o próximo disparo.
        }
    }

    // Método abstrato que determina se a torre pode atacar um alvo específico.
    // Cada tipo de torre implementará sua própria lógica para decidir quais alvos atacar.
    protected abstract bool PodeAtacar(IAtacavel atacavel);

    // Atualiza a lista de alvos no alcance, verificando todos os objetos próximos.
    void AtualizarAlvosNoAlcance()
    {
        atacaveisNoAlcance.Clear(); // Limpa a lista de alvos no início de cada atualização.

        // Detecta todos os objetos dentro do raio de alcance usando Physics2D.
        Collider2D[] alvosDetectados = Physics2D.OverlapCircleAll(transform.position, alcance);

        // Itera sobre os objetos detectados.
        foreach (Collider2D col in alvosDetectados)
        {
            // Verifica se o objeto implementa a interface IAtacavel.
            IAtacavel atacavel = col.GetComponent<IAtacavel>();

            // Adiciona o alvo à lista se ele for atacável e se a torre puder atacá-lo.
            if (atacavel != null && PodeAtacar(atacavel))
            {
                atacaveisNoAlcance.Add(atacavel);
            }
        }
    }

    // Método abstrato para realizar o ataque. As subclasses definirão como a torre ataca.
    public abstract void Atacar();

    // Método usado apenas no editor para visualizar o alcance da torre.
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; // Define a cor do gizmo como vermelho.
        Gizmos.DrawWireSphere(transform.position, alcance); // Desenha um círculo indicando o alcance da torre.
    }
}
