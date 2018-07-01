using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class responder : MonoBehaviour {

    public int idTema;

    public Text pergunta;
    public Text respostaA;
    public Text respostaB;
    public Text respostaC;
    public Text respostaD;
    public Text infoRespostas;

    public string[] perguntas;
    public string[] alternativasA;
    public string[] alternativasB;
    public string[] alternativasC;
    public string[] alternativasD;
    public string[] alternativasCorretas; // Armazena as alternativas corretas

    private int idPergunta;

    private float acertos;
    private float questoes;
    private float media;
    private int notaFinal;

    // Use this for initialization
    void Start () {
        idTema = PlayerPrefs.GetInt("idTema");
        idPergunta = 0;
        questoes = perguntas.Length;

        pergunta.text = perguntas[idPergunta];
        respostaA.text = alternativasA[idPergunta];
        respostaB.text = alternativasB[idPergunta];
        respostaC.text = alternativasC[idPergunta];
        respostaD.text = alternativasD[idPergunta];

        infoRespostas.text = "Respondendo " + (idPergunta + 1) + " de " + questoes.ToString() + " perguntas";
    }
	
    public void resposta(string alternativa)
    {
        switch (alternativa)
        {
            case "A":
                if (alternativasA[idPergunta] == alternativasCorretas[idPergunta]) {
                    acertos++;
                }
                break;
            case "B":
                if (alternativasB[idPergunta] == alternativasCorretas[idPergunta])
                {
                    acertos++;
                }
                break;
            case "C":
                if (alternativasC[idPergunta] == alternativasCorretas[idPergunta])
                {
                    acertos++;
                }
                break;
            case "D":
                if (alternativasD[idPergunta] == alternativasCorretas[idPergunta])
                {
                    acertos++;
                }
                break;
        }

        proximaPergunta();
    }

    private void proximaPergunta() {
        idPergunta++;

        if (idPergunta <= (questoes - 1))
        {
            pergunta.text = perguntas[idPergunta];
            respostaA.text = alternativasA[idPergunta];
            respostaB.text = alternativasB[idPergunta];
            respostaC.text = alternativasC[idPergunta];
            respostaD.text = alternativasD[idPergunta];

            infoRespostas.text = "Respondendo " + (idPergunta + 1) + " de " + questoes.ToString() + " perguntas";
        }
        else
        {
            media = 10 * (acertos / questoes);
            notaFinal = Mathf.RoundToInt(media);

            if(notaFinal > PlayerPrefs.GetInt("notaFinal"+idTema.ToString()))
            {
                PlayerPrefs.SetInt("notaFinal"+idTema.ToString(), notaFinal);
                PlayerPrefs.SetInt("acertos"+idTema.ToString(), (int)acertos);
            }

            PlayerPrefs.SetInt("notaFinalTemp" + idTema.ToString(), notaFinal);
            PlayerPrefs.SetInt("acertosTemp" + idTema.ToString(), (int)acertos);

            Application.LoadLevel("notaFinal");
        }
    }
}
