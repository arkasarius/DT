using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audiolibrary : MonoBehaviour
{
    public AudioClip[] letters;
    public string palabra="";
    public AudioSource audioSource;
    public InputField inputField;
    public float delay=0.075f;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void TTS(string texto) {
        texto = inputField.text;
        List<int> codes= new List<int>();
        texto = texto.ToLower();
        texto = texto.Replace(" ", "");
        texto = texto.Replace("?", "");
        texto = texto.Replace(".", "");
        texto = texto.Replace(",", "");
        texto = texto.Replace("'", "");
        texto = texto.Replace("!", "");
        char[] myChars = texto.ToCharArray();
        codes.Clear();
        foreach (char a in myChars)
        {
            //print((int)a-97);
            codes.Add((int)a - 97);
        }
        StartCoroutine(PlayStringAnimalese(codes));
    }

    IEnumerator PlayStringAnimalese(List<int> a)
    {
        foreach (int alist in a)
        {
            audioSource.clip = letters[alist];
            audioSource.Play();
            yield return new WaitForSecondsRealtime(delay);
        }
        yield return new WaitForSecondsRealtime(0.075f);
    }

    public int code=0;
    public void TTSUndertale(string texto)
    {
        texto = inputField.text;
        List<int> codes = new List<int>();
        texto = texto.ToLower();
        texto = texto.Replace(" ", "");
        texto = texto.Replace("?", "");
        texto = texto.Replace(".", "");
        texto = texto.Replace(",", "");
        texto = texto.Replace("'", "");
        texto = texto.Replace("!", "");
        char[] myChars = texto.ToCharArray();
        codes.Clear();
        foreach (char a in myChars)
        {
            //print((int)a - 97);
            codes.Add(code);
        }
        StartCoroutine(PlayStringUndertale(codes));
    }

    IEnumerator PlayStringUndertale(List<int> a)
    {
        foreach (int alist in a)
        {
            audioSource.clip = letters[alist];
            audioSource.Play();
            yield return new WaitForSecondsRealtime(delay);
        }
        yield return new WaitForSecondsRealtime(0.075f);
    }
}
