using System;

[Serializable]
public class AzureCustomVisionResponse
{
   public string id;
   public string project;
   public string iteration;
   public string created;
   public Prediction[] predictions;
}

[Serializable]
public class Prediction
{
   public float probability;
   public string tagId;
   public string tagName;
}

/*
 * Example Response
 * {
   "id":"fb7244f2-70a2-4b3b-b933-38dfd5bcdaac",
   "project":"7ff46a02-3aec-411e-89e0-42d3e747af01",
   "iteration":"9ddaed99-0022-4f6a-9952-ad3f39798574",
   "created":"2022-03-15T21:56:56.108Z",
   "predictions":[
      {
         "probability":0.99616915,
         "tagId":"ad3f55d5-1665-4db4-81a7-53c9fba655b7",
         "tagName":"TRIAXIAL ACCELEROMETER MODEL 3023A"
      },
      {
         "probability":0.0018698408,
         "tagId":"f4b52bf7-207b-41f9-892d-8355d2bdff0f",
         "tagName":"MINIATURE ACCELEROMETER MODEL 3049D"
      },
      {
         "probability":0.0013694112,
         "tagId":"78429442-552f-4cc7-905b-e9bce5d9222d",
         "tagName":"TRIAXIAL ACCELEROMETER MODEL 3143D"
      },
      {
         "probability":0.0004908287,
         "tagId":"b503af11-8032-400f-8ac4-13ee5f27a575",
         "tagName":"CHARGE MODE ACCELEROMETER MODEL 3066C"
      },
      {
         "probability":8.2786784E-05,
         "tagId":"0383d4fa-015f-444f-ab46-ec72a231d998",
         "tagName":"GENERAL PURPOSE ACCELEROMETER Model 3056C"
      },
      {
         "probability":1.5319187E-05,
         "tagId":"82866697-1ca3-4d9f-abd7-aac62553d0d2",
         "tagName":"REFERENCE ACCELEROMETER MODEL 3027B"
      },
      {
         "probability":2.2529957E-06,
         "tagId":"fe9bbe4c-6c07-4afe-a85b-4862d356080b",
         "tagName":"INDUSTRIAL ACCELEROMETER MODEL 3019A"
      },
      {
         "probability":3.3442282E-07,
         "tagId":"01d180eb-f13c-4e10-8dbe-1d3034c7f185",
         "tagName":"SHOCK ACCELEROMETER MODEL 3086A"
      },
      {
         "probability":9.3521635E-09,
         "tagId":"6aefa15b-6822-4a10-8a43-0a06b39f0659",
         "tagName":"AIRBORNE ACCELEROMETER MODEL 3062A"
      }
   ]
}
 */