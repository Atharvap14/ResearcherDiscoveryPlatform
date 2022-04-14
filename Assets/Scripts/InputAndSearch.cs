using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;


public class InputAndSearch : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField txtinput;
    
    void Start()
    {
        txtinput.text = "";   
    }

    // Search Function is called when search button is pressed. 
    public void Search()
    {
        // Starts a Coroutine -- runs asynchronously -- fetches most viewed artcles from google scholar.
        StartCoroutine(getRequest("https://serpapi.com/search.json?engine=google_scholar&q="+txtinput.text+ "&api_key=394c80f0a972a9fa1bab308cd6ddbb3a2323c7733d240724792b295e6b62c181&num=10"));
    }

    // Coroutine to fetch most viewed articles in a field.
    IEnumerator getRequest(string uri)
    {
        // Sends HTTPS request to the API
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();

        if (uwr.result==UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
           // The Code below de-serializes JSON file obtained from the HTTPS request into a object
            List<string> authorid = new List<string>();
            JsonTextReader reader = new JsonTextReader(new StringReader(uwr.downloadHandler.text));
            bool reachedauthorid = false;
            // Finds all Authors present in search results obtained
            while (reader.Read())
            {
                if (reader.Value != null)
                {
                    
                    if (reader.TokenType == JsonToken.PropertyName && reader.Value.ToString()=="author_id")
                    {
                        reachedauthorid = true;
                    }
                   else if (reachedauthorid)
                    {
                        authorid.Add(reader.Value.ToString());
                        reachedauthorid = false;
                    }
                }
               
            }
            // searches for the profiles of all authors using the Author API.
            foreach (var i in authorid)
            {
                StartCoroutine(getRequestAuthorAPI(i));
            }
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
        
        }
    // Coroutine to fetch Author profiles using author ids
    IEnumerator getRequestAuthorAPI(string authorid)
    {
        UnityWebRequest uwr = UnityWebRequest.Get("https://serpapi.com/search.json?engine=google_scholar_author&author_id="+authorid+ "&api_key=394c80f0a972a9fa1bab308cd6ddbb3a2323c7733d240724792b295e6b62c181");
        yield return uwr.SendWebRequest();

        if (uwr.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            print("Received: " + uwr.downloadHandler.text);
            string json = uwr.downloadHandler.text;
            JObject googleSearch = JObject.Parse(json);

            // get JSON result objects into a list
            JToken results = googleSearch["author"];
            List<JToken> inte = googleSearch["author"]["interests"].Children().ToList();
            JToken cites = googleSearch["cited_by"]["table"][0]["citations"];
            JToken indiceh = googleSearch["cited_by"]["table"][1]["h_index"];
            JToken indicei10 = googleSearch["cited_by"]["table"][2]["i10_index"];
            JToken public_access = googleSearch["public_access"];

            // serialize JSON results into .NET objects
            AuthorDescription temp_author = new AuthorDescription();
            temp_author.name = (string)results["name"];
            temp_author.affiliations = (string)results["affiliations"];
            temp_author.email = (string)results["email"];
            temp_author.interests = new List<Dictionary<string, string>>();
            foreach (var i in inte)
            {
                var dict = new Dictionary<string, string>();
                dict.Add("title", (string)i["title"]);
                temp_author.interests.Add(dict);
            }
            try
            {
                if (indiceh != null)
                    temp_author.indice_h = (int)indiceh["all"];
                if (indicei10["all"] != null)
                    temp_author.indice_i10 = (int)indicei10["all"];
                if (cites["all"] != null)
                    temp_author.citations = (int)cites["all"];
                if (public_access["available"] != null)
                    temp_author.pa_avail = (int)public_access["available"];
                if (public_access["not_available"] != null)
                    temp_author.pa_not_avail = (int)public_access["not_available"];
            }

            catch 
            {
                Debug.Log("Error");
            }
            // Stores the author in the database.
            DASM.Store(temp_author);
        }


    }
}

  