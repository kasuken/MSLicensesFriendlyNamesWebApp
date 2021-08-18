# MSLicensesFriendlyNamesWebApp
A web app that exposes friendly names for Azure AD product names and service plan names.
The API returns data scraped from [the Azure Active Directory documentation.](https://docs.microsoft.com/en-us/azure/active-directory/users-groups-roles/licensing-service-plan-reference).

The informations are grabbed directly from the markdown file: "https://raw.githubusercontent.com/MicrosoftDocs/azure-docs/master/articles/active-directory/enterprise-users/licensing-service-plan-reference.md

### How to use

* GET /products
```
[
  {
    "stringID": "CDSAICAPACITY",
    "id": "d2dea78b-507c-4e56-b400-39447f4738f8",
    "productName": "AI Builder Capacity add-on",
    "servicePlansIncluded": [
      {
        "id": "a7c70a41-5e02-4271-93e6-d9b4184d83f5",
        "name": "CDSAICAPACITY "
      },
      {
        "id": "113feb6c-3fe4-4440-bddc-54d774bf0318",
        "name": "EXCHANGE_S_FOUNDATION "
      }
    ],
    "servicePlansIncludedFriendlyNames": [
      {
        "id": "a7c70a41-5e02-4271-93e6-d9b4184d83f5",
        "name": "AI Builder capacity add-on "
      },
      {
        "id": "113feb6c-3fe4-4440-bddc-54d774bf0318",
        "name": "Exchange Foundation "
      }
    ]
  },
  {
    "stringID": "SPZA_IW",
    "id": "8f0c5670-4e56-4892-b06d-91c085d7004f",
    "productName": "APP CONNECT IW",
    "servicePlansIncluded": [
      {
        "id": "0bfc98ed-1dbc-4a97-b246-701754e48b17",
        "name": "SPZA "
      },
      {
        "id": "113feb6c-3fe4-4440-bddc-54d774bf0318",
        "name": "EXCHANGE_S_FOUNDATION "
      }
    ],
    "servicePlansIncludedFriendlyNames": [
      {
        "id": "0bfc98ed-1dbc-4a97-b246-701754e48b17",
        "name": "APP CONNECT "
      },
      {
        "id": "113feb6c-3fe4-4440-bddc-54d774bf0318",
        "name": "EXCHANGE FOUNDATION "
      }
    ]
  }
]
... JSON is truncated because it's too long
```

* GET /products/\<stringID>

```
{
    "productName": "EXCHANGE ONLINE ESSENTIALS",
    "stringID": "EXCHANGE_S_ESSENTIALS",
    "guid": "e8f81a67-bd96-4074-b108-cf193eb9433b",
    "servicePlansIncluded": "EXCHANGE_S_ESSENTIALS (1126bef5-da20-4f07-b45e-ad25d2581aa8)",
    "servicePlansIncludedFriendlyNames": "EXCHANGE_S_ESSENTIALS (1126bef5-da20-4f07-b45e-ad25d2581aa8)"
}
```

### Public EndPoint
I use this EndPoint for my PowerShell scripts and for my .NET application.
You can find the public endpoint here: https://mslicensesfriendlynameswebapp.azurewebsites.net/swagger/index.html

You can try the calls directly from that link with Swagger.

### Technologies
- .NET 6 Preview 7
- ASP.NET Core Minimal API

### Do you want to improve it?
Fork the project and send a Pull Request :)
