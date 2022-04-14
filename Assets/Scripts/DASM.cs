using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/* Module Data Access and Storage Module 
Functionalities for this module : Access data of the profiles stored in the format of AuthorDescription
Store: Add each author profiles
SetData: Set the data to a pre define value -- used for testing the code.
 */
public static class DASM
{
     static List<AuthorDescription> data = new List<AuthorDescription> ();
    
    // To 
    public static void Store(AuthorDescription obj)
    {
        data.Add(obj);
    }

    public static List<AuthorDescription> Access()
    {
        return data;
    }

    public static void SetData(List<AuthorDescription> obj)
    {
        data = obj;
    }

    public static void displaylength()
    {
        Debug.Log("Number of researchers found =" + data.Count.ToString());
    }
}




