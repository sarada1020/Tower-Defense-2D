using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface IAtacavel: Define um contrato para objetos que podem receber dano.
public interface IAtacavel
{
    // Método ReceberDano: Deve ser implementado por qualquer classe que herde esta interface.
    // Representa a ação de receber dano, com a quantidade de dano especificada pelo parâmetro.
    void ReceberDano(int dano);
}
