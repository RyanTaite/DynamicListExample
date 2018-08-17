# Dynamic List Example

This is a .Net Core 2.1 Razor Pages Web App using Entity Framework Core

The goal of this project is to demonstrate how to add, update, and delete Child objects from a Parent's List of Children with Ajax and PartialViews

-----

**How to Run and Steps to See Results:**

- Download project into Visual Studio (I used 2017 Professional)
- Run the program and when it loads `https://localhost:#####/` it should ask to you to click a button to "Apply Migrations", do that
- Refresh the page
- Under "Index" click the "Create New" link, type a Name for the Parent and then click the button to add a Child. Add as many children as you want. Give them all names.
- Submit the form and be redirected to the Index
- Click the "Edit" link next to your new Parent
- Add, remove, and/or update the Children
- Submit the form and be redirected to the Index
- Click either the "Edit" or "Details" link to see your changes

Children are added and removed without reloading the page and are only processed when submitting the form.

-----

This project was create using "Individual User Accounts" for it's Authentication

Requires Nuget Package [BeginCollectionItemCore](https://www.nuget.org/packages/BeginCollectionItemCore/)
- Relevant StackOverflow post: [Using BeginCollectionItem in ASP.net Core](https://stackoverflow.com/questions/38864912/using-begincollectionitem-in-asp-net-core)

In `~/Startup.cs`, Controller routing was added in the `Configure` method:

`app.UseMvc(routes => routes.MapRoute("default", "{controller}/{action=Index}/{id?}"));`
- Without this, `@Url.Action("GetChildPartialView", "Parent")` returns an empty string

The `Parent` Model class was scaffolded with "Razor Pages using Entity Framework (CRUD)" into the `~/Pages/` folder, replacing the default Index page. 

-----

_Feel free to use and suggest edits to this project, it was made purely as a learning example for myself_
