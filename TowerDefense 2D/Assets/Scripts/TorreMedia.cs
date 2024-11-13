using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe "TorreMedia", representando uma torre com força intermediária.
// Esta torre é especializada em atacar inimigos das classes InimigoVermelho e InimigoAzul.
public class TorreMedia : TorreBase
{
    public GameObject prefabMunicao; // Referência ao prefab da munição que será disparada.

    // Determina quais tipos de inimigos a torre pode atacar.
    // A "TorreMedia" ataca apenas inimigos das classes "InimigoVermelho" e "InimigoAzul".
    protected override bool PodeAtacar(IAtacavel atacavel)
    {
        return atacavel is InimigoVermelho || atacavel is InimigoAzul;
    }

    // Método que realiza o ataque da torre.
    public override void Atacar()
    {
        // Verifica se há inimigos no alcance.
        if (atacaveisNoAlcance.Count > 0)
        {
            IAtacavel alvo = atacaveisNoAlcance[0]; // Seleciona o primeiro inimigo na lista de alvos no alcance.
            Disparar(alvo); // Chama o método para disparar munição contra o inimigo.
            Debug.Log("Atirou"); // Exibe uma mensagem no console para depuração.
        }
    }

    // Método que realiza o disparo da munição contra o inimigo.
    private void Disparar(IAtacavel alvo)
    {
        // Instancia o prefab da munição na posição de spawn da torre.
        GameObject municaoObj = Instantiate(prefabMunicao, spawnPonto.position, Quaternion.identity);

        // Obtém o componente "Municao" do objeto instanciado.
        Municao municao = municaoObj.GetComponent<Municao>();

        // Inicializa a munição com o alvo e o dano da torre.
        municao.Iniciar((InimigoBase)alvo, dano);
    }
}
