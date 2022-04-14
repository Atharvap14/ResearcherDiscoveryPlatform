using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RankingFilteringModule 
{
    // Start is called before the first frame update

    // An enumeration to decide the criteria on which the raw results will be reanked.
    public enum criteria
    {
        citations,
        indice_h,
        indice_i10,
        publicavail,
    };
    public static void rank(criteria option = criteria.indice_h)
    {
        List<AuthorDescription> authors = DASM.Access();
        if (option == criteria.citations)
        {
            authors.Sort((x, y) => x.citations.CompareTo(y.citations));
        }
        else if(option == criteria.publicavail)
        {
            authors.Sort((x, y) => x.pa_avail.CompareTo(y.pa_avail));
        }
        else if (option == criteria.indice_i10)
        {
            authors.Sort((x, y) => x.indice_i10.CompareTo(y.indice_i10));
        }
        else
        {
            authors.Sort((x, y) => x.indice_h.CompareTo(y.indice_h));
        }

        DASM.SetData(authors);
    }
}
