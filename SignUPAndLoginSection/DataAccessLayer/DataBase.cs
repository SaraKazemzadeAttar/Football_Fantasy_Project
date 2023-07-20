using SignUPAndLoginSection.presentationLayer;
using System;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.businessLayer;
using System.Security.Principal;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace SignUPAndLoginSection.DataAccessLayer;

public class DataBase : DbContext
{
    public DbSet<presentationLayer.User> userTable { get; set; }
    public DbSet<Player> playerTable { get; set; }
    public DbSet<UsersTeamPlayers> UsersTeamPlayersTable{get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder)
    {
        contextOptionsBuilder.UseSqlite("Data source=database0.db");//kazemzadeh
    }
}