# Storeme
**Storeme** is ASP.NET Core web application simulating e-commerce site including the process from managing the store with an admin account to ordering products as a user, while the guests can browse the products, but need to create an account if they want to use more features like cart, wishlist or order functionality.

**Note this is the initial commit of the app and some validations, if checks and some small details are yet to be added.** <br/>

**Some views**  </br>
<img src="https://i.postimg.cc/wjhfp82b/Screenshot-1.png" width="35%"></img> <img src="https://i.postimg.cc/tTmD5XR7/Screenshot-2.png" width="35%"></img> <img src="https://i.postimg.cc/zvb72937/Screenshot-3.png" width="35%"></img> <img src="https://i.postimg.cc/0Qt5XSDP/Screenshot-8.png" width="35%"></img> <img src="https://i.postimg.cc/9MfJZ4hv/Screenshot-5.png" width="35%"></img> <img src="https://i.postimg.cc/mkvwv8Hs/Screenshot-9.png" width="35%"></img> 

**Admin account**: </br>
 *username*: admin <br>  *password*: 123456
## Getting Started

###### To run the application you need:
- .NET Core 6.0 

- If you don't have *Sql server* on your machine you should replace the configuration in *Quizaldo.Web/appsettings.json* with this code:
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=Server=(localdb)\mssqllocaldb;Database=Storeme;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```
- In your *package manger console* type: 

```
update-database
```

## Used technologies
- C#
- .NET Core 6.0
- Entity Framework Core
- SQL
- Bootstrap 5.2
- HTML
- CSS
- JavaScript
