using SignUPAndLoginSection.presentationLayer;

namespace SignUPAndLoginSection.DataAccessLayer;
using System;
using SignUPAndLoginSection.DataAccessLayer;
using System.Security.Principal;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Security.AccessControl;

public class DataBase : DbContext
{
    public DbSet<businessLayer.User> userTable { get; set; }
    public DbSet<Player> playerTable { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder)
    {
        contextOptionsBuilder.UseSqlite("Data source=database.db");
    }
}

public class Player
{
    public string first_name;
    public int id;
    public int now_cost;
    public string second_name;
    public int team;
    public int element_type;

    public int total_points;
    // photo ->string

    public Player(string first_name, int id, int now_cost, string second_name, int team, int element_type,
        int total_points)
    {
        this.first_name = first_name;
        this.element_type = element_type;
        this.id = id;
        this.second_name = second_name;
        this.total_points = total_points;
        this.now_cost = now_cost;
        this.team = team;
    }
    
}