using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    int corDaVez, acertos, erros;
    public int[] sequencia;
    [SerializeField] string[] nomes;

    private void Start()
    {
        GerarSequencia();
Debug.Log("indice da cor atual: " + GetCorDaVez());
    }

    void GerarSequencia()
    {
        corDaVez = 0;

        sequencia = new int[Random.Range(3, nomes.Length)];
        UIManager.instance.LimparTexto();

        for(int i = 0; i < sequencia.Length; i++) 
        {
            sequencia[i] = Random.Range(0, nomes.Length);
            UIManager.instance.AtualizarSequencia(nomes[sequencia[i]]);
        }
    }

    public void ChecarCor(int corIndex)
    {
        if(corIndex == sequencia[corDaVez])
        {
            corDaVez++;
            if(corDaVez == sequencia.Length)
            {
                acertos++;
                UIManager.instance.AtualizarAcertos(acertos);
                GerarSequencia();
            }

            else
            {
                UIManager.instance.AtualizarSequencia(GetProximaCorNome());
            }
        }
        else
        {
            erros++;
            UIManager.instance.AtualizarErros(erros);
            GerarSequencia();
        }
    }
    public int GetCorDaVez()
    {
        return corDaVez < sequencia.Length ? sequencia[corDaVez] : -1;
    }



    public string GetProximaCorNome()
    {

        return corDaVez < sequencia.Length ? nomes[sequencia[corDaVez]] : null;
    }
}