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
    public DbSet<user> userTable { get; set; }
    public DbSet<Player> playerTable { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder)
    {
        contextOptionsBuilder.UseSqlite("Data source=database.db");
    }
}

public class user
{
    public int userId;
    public userName username;
    public email email;
    public fullName fullname;
    public password password;
    public mobilePhone mobilePhone;

    public user(int userId_, string username_, string email_, string fullname_, string password_, string mobilephone_)
    {
        userId = userId_;
        username = new userName(username_);
        email = new email(email_);
        fullname = new fullName(fullname_);
        password = new password(password_);
        mobilePhone = new mobilePhone(mobilephone_);
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