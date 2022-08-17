# Storeme
**Storeme** is ASP.NET Core web application simulating e-commerce site including the process from managing the store with an admin account to ordering products as a user, while the guests can browse the products, but need to create an account if they want to use more feautres like cart, wishlist or order functionality.

**Some views**  </br>
<img src="https://media.giphy.com/media/vFKqnCdLPNOKc/giphy.gif" width="1000" height="475" />


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
    "DefaultConnection": "Server=.;Database=Storeme;Trusted_Connection=True;MultipleActiveResultSets=true"
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
- Bootstrap 5.2
- HTML
- CSS
- JavaScript
