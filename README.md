# Dynamic List Example

This is a .Net Core 2.1 Razor Pages Web App using Entity Framework Core

The goal of this project is to demonstrate how to add, update, and delete Child objects from a Parent's List of Children with Ajax and PartialViews

This project was create using "Individual User Accounts" for it's Authentication

Requires Nuget Package [BeginCollectionItemCore](https://www.nuget.org/packages/BeginCollectionItemCore/)
- Relevant StackOverflow post: [Using BeginCollectionItem in ASP.net Core](https://stackoverflow.com/questions/38864912/using-begincollectionitem-in-asp-net-core)

In `~/Startup.cs`, Controller routing was added in the `Configure` method:

`app.UseMvc(routes => routes.MapRoute("default", "{controller}/{action=Index}/{id?}"));`
- Without this, `@Url.Action("GetChildPartialView", "Parent")` returns an empty string

The `Parent` Model class was scaffolded with "Razor Pages using Entity Framework (CRUD)" into the `~/Pages/` folder, replacing the default Index page. 

-----

_Feel free to use and suggest edits to this project, it was made purely as a learning example for myself_
