using System;
using System.Collections;
using System.Collections.Generic;
using RestClient.Core;
using RestClient.Core.Models;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AzureComputerVisionClient : MonoBehaviour
{
    [SerializeField]
    private string baseUrl = "https://enirysvision-prediction.cognitiveservices.azure.com/customvision/v3.0/Prediction/";

    [SerializeField]
    private string clientId;

    [SerializeField]
    private string clientSecret;
    
    [SerializeField]
    private string projectId;
    
    [SerializeField]
    private string iterationName;

    [SerializeField] private bool isUrl;

    private string _imageToPredict = "";

    [SerializeField] 
    private TMP_Text predictionTxt;
    [SerializeField] 
    private TMP_Text confidenceTxt;
    [SerializeField] 
    private RawImage previewImage;
    [SerializeField]
    private TMP_InputField imageUrlField;
    [SerializeField]
    private Slider confidenceSlider;
    [SerializeField]
    private GameObject predictionResult;
    [SerializeField]
    private RawImage check;
    [SerializeField]
    private Sprite checkMark;
    [SerializeField]
    private Sprite crossMark;
    [SerializeField] 
    private TMP_Text orderTxt;

    [SerializeField] private Color redColor;
    [SerializeField] private Color greenColor;
    
    private RequestHeader _clientSecurityHeader;
    private RequestHeader _contentTypeHeader;
    private string _selectedPath = "";
    private string _predictionName = "";
    
    void Start()
    {
        // setup the request header
        _clientSecurityHeader = new RequestHeader {
            Key = clientId,
            Value = clientSecret
        };

        // setup the request header
        _contentTypeHeader = new RequestHeader {
            Key = "Content-Type",
            Value = isUrl ? "application/json" : "application/octet-stream"
        };
    }
    
    public void PickImage()
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            _selectedPath = path;
            Debug.Log( "Image path: " + _selectedPath );
            StartCoroutine(DownloadImage(_selectedPath));
        });

        Debug.Log( "Permission result: " + permission );
    }
    
    public void PredictFromFile()
    {
        // send a post request
        StartCoroutine(RestWebClient.Instance.HttpPostBinary($"{baseUrl}/{projectId}/classify/iterations/{iterationName}/image", _selectedPath, (r) => OnRequestComplete(r), new List<RequestHeader> 
        {
            _clientSecurityHeader,
            _contentTypeHeader
        }));
    }

    public void CheckOrder()
    {
        string sensorName = PlayerPrefs.GetString("Sensor name");
        check.gameObject.SetActive(true);
        orderTxt.gameObject.SetActive(true);
        if (_predictionName.Equals(sensorName))
        {
            orderTxt.text = "Order is correct!";
            orderTxt.color = greenColor;
            check.texture = checkMark.texture;
        }
        else
        {
            orderTxt.text = "Order is incorrect!";
            orderTxt.color = redColor;
            check.texture = crossMark.texture;
        }
            
    }
    
    IEnumerator DownloadImage(string MediaUrl)
    {   
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if(request.isNetworkError || request.isHttpError) 
            Debug.Log(request.error);
        else
            previewImage.texture = ((DownloadHandlerTexture) request.downloadHandler).texture;
    } 

    public void PredictFromURL()
    {
        // validation
        if(string.IsNullOrEmpty(imageUrlField.text))
        {
            Debug.LogError("imageToPredict needs to be set through the inspector...");
            return;
        }
        
        _imageToPredict = imageUrlField.text;
        StartCoroutine(DownloadImage(_imageToPredict));

        // build image url required by Azure Custom Vision
        ImageUrl imageUrl = new ImageUrl { Url = _imageToPredict };
        
        // send a post request
        StartCoroutine(RestWebClient.Instance.HttpPost($"{baseUrl}/{projectId}/classify/iterations/{iterationName}/url", JsonUtility.ToJson(imageUrl), (r) => OnRequestComplete(r), new List<RequestHeader> 
        {
            _clientSecurityHeader,
            _contentTypeHeader
        }));
    }

    void OnRequestComplete(Response response)
    {
        Debug.Log($"Status Code: {response.StatusCode}");
        Debug.Log($"Data: {response.Data}");
        Debug.Log($"Error: {response.Error}");
        
        if(string.IsNullOrEmpty(response.Error) && !string.IsNullOrEmpty(response.Data))
        {
            AzureCustomVisionResponse azureCustomVisionResponse = JsonUtility.FromJson<AzureCustomVisionResponse>(response.Data);
            
            // show the prediction with the highest probability
            confidenceTxt.text = "Confidence " + (azureCustomVisionResponse.predictions[0].probability * 100).ToString("0.00") + "%";
            _predictionName = azureCustomVisionResponse.predictions[0].tagName;
            predictionTxt.text = _predictionName;
            confidenceSlider.value = azureCustomVisionResponse.predictions[0].probability;
            predictionResult.SetActive(true);
            string[] modelName = _predictionName.Split(' ');
            string reference = modelName[modelName.Length - 1];
            HomeMenuController.Instance.SensorModel = Resources.Load("3DModels/Prefabs/" + reference) as GameObject;
        }
    }

    public class ImageUrl 
    {
        public string Url;
    }
}
