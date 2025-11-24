using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ItemSpawner : MonoBehaviour
{
    [Header("Itens (ordem aleatória, sem repetição)")]
    public List<GameObject> itens = new List<GameObject>();

    [Header("Pontos fixos onde os itens aparecerão")]
    public Transform[] spawnPoints;

    [Header("Objeto da porta branca a ser ativado no final")]
    public GameObject portaFinal;

    [Header("Tempo até encerrar (segundos)")]
    public float tempoFinal = 30f;

    private List<GameObject> itensRestantes;
    private int spawnIndexAtual = 0;
    private bool finalAtivado = false;

    void Start()
    {
        itensRestantes = new List<GameObject>(itens);

        if (portaFinal != null)
            portaFinal.SetActive(false);
    }

    public void SpawnProximoItem(Button botaoChamador)
    {
        if (spawnIndexAtual >= spawnPoints.Length || itensRestantes.Count == 0)
        {
            botaoChamador.interactable = false;
            return;
        }

        int rand = Random.Range(0, itensRestantes.Count);
        GameObject itemEscolhido = itensRestantes[rand];

        Transform spawn = spawnPoints[spawnIndexAtual];

        Instantiate(itemEscolhido, spawn.position, spawn.rotation);

        itensRestantes.RemoveAt(rand);
        spawnIndexAtual++;

        // Se foi o último item → aparece a porta final
        if (spawnIndexAtual >= itens.Count && !finalAtivado)
        {
            finalAtivado = true;
            Debug.Log("[FINAL] Todas as memórias recuperadas!");

            if (portaFinal != null)
                portaFinal.SetActive(true);

            botaoChamador.interactable = false;

            // INICIA O TIMER DE FINALIZAÇÃO
            StartCoroutine(ContagemFinal());
        }
    }

    // COROUTINE DO TIMER FINAL
    private IEnumerator ContagemFinal()
    {
        Debug.Log("[FINAL] Timer iniciado. Jogo encerra em " + tempoFinal + " segundos.");

        yield return new WaitForSeconds(tempoFinal);

        EncerrarJogo();
    }

    // ENCERRA O JOGO DE FORMA ADEQUADA (Unity Editor, PC ou Android)
    private void EncerrarJogo()
    {
        Debug.Log("[FINAL] Jogo encerrado.");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_ANDROID
        Application.Quit();
#else
        Application.Quit();
#endif
    }
}
