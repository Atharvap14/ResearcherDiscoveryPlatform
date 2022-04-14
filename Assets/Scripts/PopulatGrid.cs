using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopulatGrid : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    public int numToCreate = 1;
    List<GameObject> populated = new List<GameObject>();
    void Start()
    {
        
    }
    private void Update()
    {
        Populate(); // Will constantly update UI whenever there are new responses from the API server.
    }
    public void Populate() // Populate the scoll View with cards for each Author profile.
    {
        foreach(var i in populated)
        {
            Destroy(i); // Clear previously present cards
        }
        numToCreate = DASM.Access().Count;
        var data = DASM.Access();
        
        GameObject newcard;
        // Copying data into Cards  and formatting it for UI
        for (int i = 0; i < numToCreate; i++)
        {
            newcard = (GameObject)Instantiate(prefab, transform);
            var nametransform=newcard.transform.GetChild(0);
            var intereststransform = newcard.transform.GetChild(1);
            var citetransform = newcard.transform.GetChild(2);
            var hindextransform = newcard.transform.GetChild(3);
            var i10inddextransform = newcard.transform.GetChild(4);
            var affliationtransform = newcard.transform.GetChild(5);
            var emailtransform = newcard.transform.GetChild(6);
            nametransform.GetComponent<TMPro.TextMeshProUGUI>().text = "Name: "+data[i].name;
            emailtransform.GetComponent<TMPro.TextMeshProUGUI>().text = "Email: "+data[i].email;
            affliationtransform.GetComponent<TMPro.TextMeshProUGUI>().text = "Affiliations: " + data[i].affiliations;
            citetransform.GetComponent<TMPro.TextMeshProUGUI>().text = "Citations: " + data[i].citations.ToString();
            hindextransform.GetComponent<TMPro.TextMeshProUGUI>().text = "h-index: " + data[i].indice_h.ToString();
            i10inddextransform.GetComponent<TMPro.TextMeshProUGUI>().text = "i10-index: " + data[i].indice_i10.ToString();
            string interest = "";
            bool first = true;
            foreach(var j in data[i].interests)
            {
                if (first) {
                    interest += j["title"];
                    first = false;
                }
                else
                {
                    interest += (", "+j["title"]);
                }
                intereststransform.GetComponent<TMPro.TextMeshProUGUI>().text = "Interests: " + interest;   
            }
            populated.Add(newcard);
            
        }
    }
}
