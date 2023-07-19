using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using UnityEngine.Networking;

using Unity.Jobs;
using System;

public class CacluateWPT : MonoBehaviour
{

    public InputField Pno;
    public InputField token;
    public Text result;
    public Button checkBtn;


    public void Start()
    {
        checkBtn.onClick.AddListener(() => CheckData());
    }



    public void CheckData()
    {
        string project = Pno.text;
        string token = this.token.text;

        string url = "https://cac-dpd-discoveryservice-api-uat.hatchbimdev.com/api/project/getapplicationinstances/{{Project}}";

        url = url.Replace("{{Project}}", project);

        StartCoroutine(GetAPI(url, token));

    }

    private IEnumerator GetAPI(string url, string token)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        webRequest.SetRequestHeader("authorization", token);

        yield return webRequest.SendWebRequest();

        string data = webRequest.downloadHandler.text;
        print(data);

        List<Root> awesomeData = JsonConvert.DeserializeObject<List<Root>>(data);

        print(awesomeData.Count);

        if (awesomeData[0].isActive == true && awesomeData[0].system == "PackageShare")
        {
            result.text = "This is PS2";


        }

        else
        {
            result.text = "This is PS1";
        }

        }


}



public class Root
{
    public int id { get; set; }
    public int systemsConfigurationId { get; set; }
    public object systemsConfiguration { get; set; }
    public string code { get; set; }
    public string hmiAddress { get; set; }
    public string system { get; set; }
    public string project { get; set; }
    public string applicationServer { get; set; }
    public object applicationServerUrl { get; set; }
    public string databaseServer { get; set; }
    public string storageRoot { get; set; }
    public string storageServer { get; set; }
    public object ipAddress { get; set; }
    public object dnsName { get; set; }
    public string executionOfficeCode { get; set; }
    public string executionOffice { get; set; }
    public object regionCode { get; set; }
    public object regionName { get; set; }
    public string locationCode { get; set; }
    public object locationName { get; set; }
    public string environment { get; set; }
    public DateTime? createdDate { get; set; }
    public string createdBy { get; set; }
    public DateTime? modifiedDate { get; set; }
    public string modifiedBy { get; set; }
    public bool isDeleted { get; set; }
    public bool isActive { get; set; }
    public object adfPipelineName { get; set; }
    public object adhocPipelineName { get; set; }
    public object collectionGroup { get; set; }
    public object objectGroup { get; set; }
    public string contactCode { get; set; }
    public string emailAddress { get; set; }
    public string listType { get; set; }
}


