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
    
    public user(int userId_ , string username_ ,string email_,string fullname_,string password_ ,string mobilephone_)
    {
        userId = userId_;
        username = new userName(username_);
        email = new email(email_);
        fullname = new fullName(fullname_);
        password = new password(password_);
        mobilePhone = new mobilePhone(mobilephone_);
    }

}