using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TestDASM();
        TestInputSearch("Computer Vision");
        TestRankingandFiltering();
        

    }

    void TestDASM() {
        // initial state of database
        foreach (var i in DASM.Access())
        {
            i.display();
        }
        AuthorDescription temp_author = new AuthorDescription();
        temp_author.citations = 23;
        temp_author.affiliations = "IIt Jodhpur";
        temp_author.email = "xyz@gmail.com";
        temp_author.indice_h = 12;
        temp_author.indice_i10 = 1;
        temp_author.pa_avail = 0;
        temp_author.pa_not_avail = 0;
        temp_author.name = "Rajesh";
        // State of database after Using Store Function 
        DASM.Store(temp_author);
        foreach (var i in DASM.Access())
        {
            i.display();
        }
        AuthorDescription temp_author1 = new AuthorDescription();
        temp_author1.citations = 43;
        temp_author1.affiliations = "IIt Bombay";
        temp_author1.email = "acb@gmail.com";
        temp_author1.indice_h = 3;
        temp_author1.indice_i10 = 2;
        temp_author1.pa_avail = 7;
        temp_author1.pa_not_avail = 4;
        temp_author1.name = "Abhishek";

        List<AuthorDescription> list = new List<AuthorDescription>();
        list.Add(temp_author);
        list.Add(temp_author1);
        // State of database after Using SetData Function 
        DASM.SetData(list);

        foreach (var i in DASM.Access())
        {
            i.display();
        }

    }
    void TestInputSearch(string q)
    {
        // tests against query q
        InputAndSearch inp = new InputAndSearch();
        inp.txtinput.text = q;
        inp.Search();
        foreach(var i in DASM.Access())
        {
            i.display();
        }
    }

    void TestRankingandFiltering() {
        AuthorDescription temp_author = new AuthorDescription();
        temp_author.citations = 23;
        temp_author.affiliations = "IIt Jodhpur";
        temp_author.email = "xyz@gmail.com";
        temp_author.indice_h = 12;
        temp_author.indice_i10 = 1;
        temp_author.pa_avail = 0;
        temp_author.pa_not_avail = 0;
        temp_author.name = "Rajesh";

        AuthorDescription temp_author1 = new AuthorDescription();
        temp_author1.citations = 43;
        temp_author1.affiliations = "IIt Bombay";
        temp_author1.email = "acb@gmail.com";
        temp_author1.indice_h = 3;
        temp_author1.indice_i10 = 2;
        temp_author1.pa_avail = 7;
        temp_author1.pa_not_avail = 4;
        temp_author1.name = "Abhishek";

        List<AuthorDescription> list = new List<AuthorDescription>();
        list.Add(temp_author);
        list.Add(temp_author1);
        // State of database after Using SetData Function 
        DASM.SetData(list);

        foreach (var i in DASM.Access())
        {
            i.display();
        }
        // State of database after ranking based on citations 
        RankingFilteringModule.rank(RankingFilteringModule.criteria.citations);
        foreach (var i in DASM.Access())
        {
            i.display();
        }
        // State of database after ranking based on h-index 

        RankingFilteringModule.rank(RankingFilteringModule.criteria.indice_h);
        foreach (var i in DASM.Access())
        {
            i.display();
        }
        // State of database after ranking based on i10-index 

        RankingFilteringModule.rank(RankingFilteringModule.criteria.indice_i10);
        foreach (var i in DASM.Access())
        {
            i.display();
        }
        // State of database after ranking based on public access articles 

        RankingFilteringModule.rank(RankingFilteringModule.criteria.publicavail);
        foreach (var i in DASM.Access())
        {
            i.display();
        }
    }

}
