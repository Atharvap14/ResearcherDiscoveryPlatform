using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// This file is use to test deserializing algorithm used in Input and search class and define the data structure.

public class Deseializer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        // Task is to convert the following json to a custom datatype.
        string json = @"{
  'search_metadata': {
    'id': '60802ce5de983402dbe1ae4c',
    'status': 'Success',
    'json_endpoint': 'https://serpapi.com/searches/79beba2444307aad/60802ce5de983402dbe1ae4c.json',
    'created_at': '2021-04-21 13:47:17 UTC',
    'processed_at': '2021-04-21 13:47:18 UTC',
    'google_scholar_author_url': 'https://scholar.google.com/citations?user=LSsXyncAAAAJ&hl=en',
    'raw_html_file': 'https://serpapi.com/searches/79beba2444307aad/60802ce5de983402dbe1ae4c.html',
    'total_time_taken': 1.26
  },
  'search_parameters': {
    'engine': 'google_scholar_author',
    'author_id': 'LSsXyncAAAAJ',
    'hl': 'en'
  },
  'author': {
    'name': 'Cliff Meyer',
    'affiliations': 'Dana-Farber Cancer Institute and Harvard T.H. Chan School of Public Health',
    'email': 'Adresse email validée de jimmy.harvard.edu',
    'interests': [
      {
        'title': 'Computational Biology',
        'link': 'https://scholar.google.com/citations?view_op=search_authors&hl=en&mauthors=label:computational_biology',
        'serpapi_link': 'https://serpapi.com/search.json?engine=google_scholar_profiles&hl=en&mauthors=label%3Acomputational_biology'
      },
      {
        'title': 'Epigenetics',
        'link': 'https://scholar.google.com/citations?view_op=search_authors&hl=en&mauthors=label:epigenetics',
        'serpapi_link': 'https://serpapi.com/search.json?engine=google_scholar_profiles&hl=en&mauthors=label%3Aepigenetics'
      },
      {
        'title': 'Gene Regulation',
        'link': 'https://scholar.google.com/citations?view_op=search_authors&hl=en&mauthors=label:gene_regulation',
        'serpapi_link': 'https://serpapi.com/search.json?engine=google_scholar_profiles&hl=en&mauthors=label%3Agene_regulation'
      },
    ],
    'thumbnail': 'https://scholar.google.com/citations/images/avatar_scholar_128.png'
  },
  'articles': [
    {
      'title': 'Model-based analysis of ChIP-Seq (MACS)',
      'link': 'https://scholar.google.com/citations?view_op=view_citation&hl=fr&user=LSsXyncAAAAJ&citation_for_view=LSsXyncAAAAJ:2osOgNQ5qMEC',
      'citation_id': 'LSsXyncAAAAJ:2osOgNQ5qMEC',
      'authors': 'Y Zhang, T Liu, CA Meyer, J Eeckhoute, DS Johnson, BE Bernstein, ...',
      'publication': 'Genome biology 9 (9), 1-9, 2008',
      'cited_by': {
        'value': 9186,
        'link': 'https://scholar.google.com/scholar?oi=bibs&hl=fr&cites=14252090027271643524',
        'serpapi_link': 'https://serpapi.com/search.json?cites=14252090027271643524&engine=google_scholar&hl=en'
      },
      'year': '2008'
    },
    {
      'title': 'Genome-wide analysis of estrogen receptor binding sites',
      'link': 'https://scholar.google.com/citations?view_op=view_citation&hl=fr&user=LSsXyncAAAAJ&citation_for_view=LSsXyncAAAAJ:9yKSN-GCB0IC',
      'citation_id': 'LSsXyncAAAAJ:9yKSN-GCB0IC',
      'authors': 'JS Carroll, CA Meyer, J Song, W Li, TR Geistlinger, J Eeckhoute, ...',
      'publication': 'Nature genetics 38 (11), 1289-1297, 2006',
      'cited_by': {
        'value': 1464,
        'link': 'https://scholar.google.com/scholar?oi=bibs&hl=fr&cites=7951096779388712529',
        'serpapi_link': 'https://serpapi.com/search.json?cites=7951096779388712529&engine=google_scholar&hl=en'
      },
      'year': '2006'
    },
    {
      'title': 'Chromosome-wide mapping of estrogen receptor binding reveals long-range regulation requiring the forkhead protein FoxA1',
      'link': 'https://scholar.google.com/citations?view_op=view_citation&hl=fr&user=LSsXyncAAAAJ&citation_for_view=LSsXyncAAAAJ:d1gkVwhDpl0C',
      'citation_id': 'LSsXyncAAAAJ:d1gkVwhDpl0C',
      'authors': 'JS Carroll, XS Liu, AS Brodsky, W Li, CA Meyer, AJ Szary, J Eeckhoute, ...',
      'publication': 'Cell 122 (1), 33-43, 2005',
      'cited_by': {
        'value': 1371,
        'link': 'https://scholar.google.com/scholar?oi=bibs&hl=fr&cites=12018554524946333077',
        'serpapi_link': 'https://serpapi.com/search.json?cites=12018554524946333077&engine=google_scholar&hl=en'
      },
      'year': '2005'
    },
    
  ],
  'cited_by': {
    'table': [
      {
        'citations': {
          'all': 21934,
          'depuis_2016': 12302
        }
      },
      {
        'indice_h': {
          'all': 45,
          'depuis_2016': 36
        }
      },
      {
        'indice_i10': {
          'all': 59,
          'depuis_2016': 51
        }
      }
    ],
    'graph': [
      {
        'year': 2004,
        'citations': '59'
      },
      {
        'year': 2005,
        'citations': '65'
      },
      {
        'year': 2006,
        'citations': '159'
      },
      
    ]
  },
  'public_access': {
    'link': 'https://scholar.google.com/citations?view_op=list_mandates&hl=fr&user=LSsXyncAAAAJ',
    'available': 39,
    'not_available': 0
  },
  'co_authors': [
    {
      'name': 'Myles Brown',
      'link': 'https://scholar.google.com/citations?user=wwxk-JMAAAAJ&hl=fr',
      'serpapi_link': 'https://serpapi.com/search.json?author_id=wwxk-JMAAAAJ&engine=google_scholar_author&hl=en',
      'author_id': 'wwxk-JMAAAAJ',
      'affiliations': 'Emil Frei III Professor of Medicine, Dana-Farber Cancer Institute and Harvard Medical School',
      'email': 'Adresse e-mail validée de dfci.harvard.edu',
      'thumbnail': 'https://scholar.googleusercontent.com/citations?view_op=small_photo&user=wwxk-JMAAAAJ&citpid=10'
    },
    {
      'name': 'Wei Li',
      'link': 'https://scholar.google.com/citations?user=7IUCbE4AAAAJ&hl=fr',
      'serpapi_link': 'https://serpapi.com/search.json?author_id=7IUCbE4AAAAJ&engine=google_scholar_author&hl=en',
      'author_id': '7IUCbE4AAAAJ',
      'affiliations': 'Professor of Bioinformatics, University of California Irvine; Baylor College of Medicine',
      'email': 'Adresse e-mail validée de uci.edu',
      'thumbnail': 'https://scholar.googleusercontent.com/citations?view_op=small_photo&user=7IUCbE4AAAAJ&citpid=5'
    },
    {
      'name': 'Tao Liu',
      'link': 'https://scholar.google.com/citations?user=04GHe_kAAAAJ&hl=fr',
      'serpapi_link': 'https://serpapi.com/search.json?author_id=04GHe_kAAAAJ&engine=google_scholar_author&hl=en',
      'author_id': '04GHe_kAAAAJ',
      'affiliations': 'Assistant Professor, Roswell Park Comprehensive Cancer Center',
      'email': 'Adresse e-mail validée de roswellpark.org',
      'thumbnail': 'https://scholar.googleusercontent.com/citations?view_op=small_photo&user=04GHe_kAAAAJ&citpid=2'
    },
    
  ],
  'serpapi_pagination': {
    'next': 'https://serpapi.com/search.json?author_id=LSsXyncAAAAJ&cstart=20&engine=google_scholar_author&hl=en'
  }
}";

        JObject googleSearch = JObject.Parse(json);

        // get JSON result objects into a list
        JToken results = googleSearch["author"];
        List<JToken> inte = googleSearch["author"]["interests"].Children().ToList();
        JToken cites = googleSearch["cited_by"]["table"][0]["citations"];
        JToken indiceh = googleSearch["cited_by"]["table"][1]["indice_h"];
        JToken indicei10 = googleSearch["cited_by"]["table"][2]["indice_i10"];
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
        temp_author.indice_h = (int)indiceh["all"];
        temp_author.indice_i10 = (int)indicei10["all"];
        temp_author.citations = (int)cites["all"];
        temp_author.pa_avail = (int)public_access["available"];
        temp_author.pa_not_avail = (int)public_access["not_available"];
        temp_author.display();
        DASM.Store(temp_author);
        DASM.Store(temp_author);
    }
}




public class AuthorDescription
{
    public string name { get; set; }
    public string affiliations { get; set; }
    public string email { get; set; }
    public List<Dictionary<string, string>> interests { get; set; }
    public int citations { get; set; }
    public int indice_h { get; set; }
    public int indice_i10 { get; set; }
    public int pa_avail { get; set; }
    public int pa_not_avail { get; set; }

    public void display()
    {
        Debug.Log("name: " + name);
        Debug.Log("affiliations: " + affiliations);
        Debug.Log("email: " + email);
        Debug.Log("interests: " + interests);
        Debug.Log("citations: " + citations);
        Debug.Log("indice_h: " + indice_h);
        Debug.Log("indice_i10: " + indice_i10);
        Debug.Log("pa_avail: " + pa_avail);
        Debug.Log("pa_not_avail: " + pa_not_avail);
    }
}