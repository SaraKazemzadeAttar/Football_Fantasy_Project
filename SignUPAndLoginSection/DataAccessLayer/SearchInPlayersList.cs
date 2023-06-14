using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SignUPAndLoginSection.Model;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.presentationLayer;
using SignUPAndLoginSection.businessLayer;

namespace SignUPAndLoginSection.DataAccessLayer;

public class SearchInPlayersList
{
    public static List<string> searchingmethod(string entry)
    {
        List<string> fullName = new List<string>();
        List<string> foundNames = new List<string>();
        
        foreach (var player in ListOfPlayers.getListOfPlayers())
        {
            fullName.Add(player.first_name + player.second_name);
        }
        
        foreach (var playerFullName in fullName)
        {
            if (playerFullName.Contains(entry))
            {
                foundNames.Add(playerFullName);
            }
        }

        return foundNames;

    }