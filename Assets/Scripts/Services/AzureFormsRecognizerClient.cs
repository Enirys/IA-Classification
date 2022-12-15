using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using RestClient.Core;
using RestClient.Core.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AzureFormsRecognizerClient : MonoBehaviour
{
    [SerializeField]
    private string baseUrl = "https://enirysform.cognitiveservices.azure.com/formrecognizer/documentModels/prebuilt-invoice:analyze?api-version=2022-01-30-preview";

    [SerializeField]
    private string clientId;

    [SerializeField]
    private string clientSecret;

    [SerializeField]
    private TMP_InputField fileUrlField;
    [SerializeField]
    private Button analyzeBtn;
    [SerializeField]
    private Button getResultsBtn;
    [SerializeField]
    private Button makePredictionsBtn;
    [SerializeField] 
    private TMP_Text predictionTxt;
    [SerializeField] 
    private TMP_Text predictionTitleTxt;
    
    private RequestHeader _clientSecurityHeader;
    private RequestHeader _contentTypeHeader;
    private string _operationLocation;
    
    
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
            Value = "application/json"
        };
    }

    public void AnalyzeFile()
    {
        // validation
        if(string.IsNullOrEmpty(fileUrlField.text))
        {
            Debug.LogError("fileToRecognize needs to be set through the inspector...");
            return;
        }

        // build file url required by Azure Forms Recognizer
        FileUrl fileUrl = new FileUrl { urlSource = fileUrlField.text };
        
        // send a post request
        StartCoroutine(RestWebClient.Instance.HttpPost(baseUrl, JsonUtility.ToJson(fileUrl), (r) => OnRequestComplete(r), new List<RequestHeader> 
        {
            _clientSecurityHeader,
            _contentTypeHeader
        }));
    }

    public void GetAnalyzeResults()
    {
        // setup the request header
        RequestHeader clientSecurityHeader = new RequestHeader {
            Key = clientId,
            Value = clientSecret
        };
        
        // send a get request
        StartCoroutine(RestWebClient.Instance.HttpGetHeaders(_operationLocation, (r) => OnGetRequestComplete(r), new List<RequestHeader> 
        {
            clientSecurityHeader
        }));
    }
    
    void OnGetRequestComplete(Response response)
    {
        Debug.Log($"Status Code: {response.StatusCode}");
        Debug.Log($"Data: {response.Data}");
        Debug.Log($"Error: {response.Error}");
        
        if(string.IsNullOrEmpty(response.Error) && !string.IsNullOrEmpty(response.Data))
        {
            AzureFormsRecognizerResponse azureFormsRecognizerResponse =
                JsonConvert.DeserializeObject<AzureFormsRecognizerResponse>(response.Data);
            string _sensorName =  azureFormsRecognizerResponse.analyzeResult.tables[0].cells[4].content;
            predictionTxt.gameObject.SetActive(true);
            predictionTxt.text = _sensorName;
            PlayerPrefs.SetString("Sensor name", _sensorName);
            getResultsBtn.interactable = false;
            makePredictionsBtn.interactable = true;
        }
    }

    void OnRequestComplete(Response response)
    {
        Debug.Log($"Status Code: {response.StatusCode}");
        Debug.Log($"Data: {response.Data}");
        Debug.Log($"Error: {response.Error}");
        response.Headers.TryGetValue("Operation-Location", out _operationLocation);
        analyzeBtn.interactable = false;
        getResultsBtn.interactable = true;
    }

    public class FileUrl 
    {
        public string urlSource;
    }
}
