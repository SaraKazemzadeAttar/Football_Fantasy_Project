using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
//using SignUPAndLoginSection.Model;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.presentationLayer;
using SignUPAndLoginSection.businessLayer;
namespace SignUPAndLoginSection.DataAccessLayer;

public class SearchInPlayersList
{    public List<string> fullName = new List<string>();
    public List<string> FullNameOfPlayers()
    {
        foreach (var player in ListOfPlayers.getListOfPlayers())
        {
            fullName.Add(player.first_name + player.second_name);
        }

        return fullName;
    }
    public  List<string> Searchingmethod(string entry)
    {
        
        List<string> foundNames = new List<string>();
        
        foreach (var playerFullName in fullName)
        {
            if (playerFullName.Contains(entry))
            {
                foundNames.Add(playerFullName);
            }
        }

        return foundNames;

    }
}