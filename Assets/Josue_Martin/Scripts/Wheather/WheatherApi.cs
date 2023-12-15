using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;
using UnityEditor;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Experimental.GlobalIllumination;



public class WheatherApi : MonoBehaviour
    {
        [SerializeField] private WeatherData data;
        private static float latitude = 34.69374f;
        private static float longitud = 135.50218f;
        private static string units = "metrics";
        private static readonly string apiKey = "3aeeee54ec938668d4487e9c80650d49";
        public float speed;
        
        private string getWeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitud}&appid={apiKey}&units=metric";

        //https://api.openweathermap.org/data/2.5/weather?lat=34.69374&lon=135.50218&appid=3aeeee54ec938668d4487e9c80650d49&units=metric
        private string json;

    [SerializeField] private Light directionalLight;
    [SerializeField] private Color colorToChange;
    [SerializeField] private float colorChangeSpeed = 1;
    [SerializeField] private float bloomIntensity;
    [SerializeField] private float chromIntensity;
    [SerializeField] private PostProcessVolume postProcessing;
    private Bloom bloom;
    private ChromaticAberration chrom;

    private void Start()
    {
        postProcessing.profile.TryGetSettings(out bloom);
        postProcessing.profile.TryGetSettings(out chrom);

        StartCoroutine(WeatherUpdate());
    }

    public bool scaled = true;


    private void Update()
    {

    }

    IEnumerator WeatherUpdate()
    {
        while (true)
        {
            UnityWebRequest request = new UnityWebRequest(getWeatherUrl);

            request.downloadHandler = new DownloadHandlerBuffer();

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(request.error);
            }

            else
            {
                Debug.Log(request.downloadHandler.text);
                json = request.downloadHandler.text;
                DecodeJson();
                GetColorAndBloomAndChrom();
                StartCoroutine(ChangeLightColor());
                StartCoroutine(ChangeBloomIntensity());
                StartCoroutine(ChangeChromIntensity());
            }


            yield return new WaitForSecondsRealtime(600f);
        }

    }

    private IEnumerator ChangeLightColor()
    {
        //que lo metió en una corrutina en lugar de dejarlo en void, para que pueda usar el Time.deltaTime sin meterlo en el update

        yield return new WaitUntil(() => ActualLight() == colorToChange);    //Espera hasta que... el color sea igual al del colorToChange
    }

    private IEnumerator ChangeBloomIntensity()
    {
        yield return new WaitUntil(() => ActualBloom().intensity.value == bloomIntensity);
    }

    private IEnumerator ChangeChromIntensity()
    {
        yield return new WaitUntil(() => ActualChrom().intensity.value == chromIntensity);
    }

    private Color ActualLight()     //va cambiando del color en el que está hacia el color que está actualmente
    {
        directionalLight.color = Color.Lerp(directionalLight.color, colorToChange, colorChangeSpeed * Time.deltaTime);
        return directionalLight.color;
    }

    private Bloom ActualBloom()
    {
        bloom.intensity.value = bloomIntensity;
        return bloom;
    }

    private ChromaticAberration ActualChrom()
    {
        chrom.intensity.value = chromIntensity;
        return chrom;
    }

    private void GetColorAndBloomAndChrom()
    {
        switch (data.actualTemp)
        {
            case var temp when data.actualTemp <= 0:
                {
                    colorToChange = Color.blue;
                    bloomIntensity = 0f;
                    chromIntensity = 0f;
                    break;
                }

            case var temp when data.actualTemp > 0 && data.actualTemp <= 15:
                {
                    colorToChange = Color.green;
                    bloomIntensity = 5f;
                    chromIntensity = 0.33f;
                    break;
                }

            case var temp when data.actualTemp > 15 && data.actualTemp <= 30:
                {
                    colorToChange = Color.yellow;
                    bloomIntensity = 10f;
                    chromIntensity = 0.66f;
                    break;
                }

            case var temp when data.actualTemp > 30:
                {
                    colorToChange = Color.red;
                    bloomIntensity = 15f;
                    chromIntensity = 1f;
                    break;
                }
        }
    }

    private void DecodeJson()
    {
        var weatherJson = JSON.Parse(json);

        data.country = weatherJson["sys"]["country"].Value;
        data.city = weatherJson["name"].Value;
        data.actualTemp = float.Parse(weatherJson["main"]["temp"].Value);
        data.description = weatherJson["weather"][0]["description"].Value;
        data.windSpeed = float.Parse(weatherJson["wind"]["speed"].Value);

    }

}

   


 