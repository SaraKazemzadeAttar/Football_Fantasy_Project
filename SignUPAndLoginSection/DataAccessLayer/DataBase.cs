using SignUPAndLoginSection.presentationLayer;
using System;
using SignUPAndLoginSection.DataAccessLayer;
using System.Security.Principal;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace SignUPAndLoginSection.DataAccessLayer;

public class DataBase : DbContext
{
    public DbSet<presentationLayer.User> userTable { get; set; }
    public DbSet<businessLayer.Player> playerTable { get; set; }
    
    //public DbSet<DataAccessLayer.UsersTeamPlayers> UsersTeamPlayersTable { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder)
    {
        contextOptionsBuilder.UseSqlite("Data source=database.db");
    }
}