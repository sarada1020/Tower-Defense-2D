using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Uma classe base abstrata para torres no jogo.
// Esta classe define comportamentos comuns e propriedades compartilhadas entre diferentes tipos de torres.
public abstract class TorreBase : MonoBehaviour
{
    public float alcance; // O alcance da torre, determinando at� onde ela pode detectar inimigos.
    public int dano; // O dano causado pela torre ao atacar.
    public Transform spawnPonto; // O ponto de spawn da muni��o (onde os tiros ou proj�teis ser�o gerados).
    public float intervaloDeDisparo = 1.5f; // Tempo (em segundos) entre cada ataque da torre.

    private float contadorDeDisparo = 0f; // Um contador usado para controlar o intervalo de disparo.
    protected List<IAtacavel> atacaveisNoAlcance = new List<IAtacavel>();
    // Lista de objetos que podem ser atacados e est�o dentro do alcance.

    // M�todo chamado a cada frame pelo Unity.
    void Update()
    {
        AtualizarAlvosNoAlcance(); // Atualiza a lista de alvos dentro do alcance da torre.
        contadorDeDisparo -= Time.deltaTime; // Reduz o contador de disparo conforme o tempo passa.

        // Se houver alvos no alcance e o intervalo de disparo tiver terminado:
        if (atacaveisNoAlcance.Count > 0 && contadorDeDisparo <= 0)
        {
            Atacar(); // Realiza o ataque (implementado nas subclasses).
            contadorDeDisparo = intervaloDeDisparo; // Reinicia o contador para o pr�ximo disparo.
        }
    }

    // M�todo abstrato que determina se a torre pode atacar um alvo espec�fico.
    // Cada tipo de torre implementar� sua pr�pria l�gica para decidir quais alvos atacar.
    protected abstract bool PodeAtacar(IAtacavel atacavel);

    // Atualiza a lista de alvos no alcance, verificando todos os objetos pr�ximos.
    void AtualizarAlvosNoAlcance()
    {
        atacaveisNoAlcance.Clear(); // Limpa a lista de alvos no in�cio de cada atualiza��o.

        // Detecta todos os objetos dentro do raio de alcance usando Physics2D.
        Collider2D[] alvosDetectados = Physics2D.OverlapCircleAll(transform.position, alcance);

        // Itera sobre os objetos detectados.
        foreach (Collider2D col in alvosDetectados)
        {
            // Verifica se o objeto implementa a interface IAtacavel.
            IAtacavel atacavel = col.GetComponent<IAtacavel>();

            // Adiciona o alvo � lista se ele for atac�vel e se a torre puder atac�-lo.
            if (atacavel != null && PodeAtacar(atacavel))
            {
                atacaveisNoAlcance.Add(atacavel);
            }
        }
    }

    // M�todo abstrato para realizar o ataque. As subclasses definir�o como a torre ataca.
    public abstract void Atacar();

    // M�todo usado apenas no editor para visualizar o alcance da torre.
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; // Define a cor do gizmo como vermelho.
        Gizmos.DrawWireSphere(transform.position, alcance); // Desenha um c�rculo indicando o alcance da torre.
    }
}
