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
    public DbSet<businessLayer.Player> playerTable { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder)
    {
        contextOptionsBuilder.UseSqlite("Data source=database.db");
    }
}

