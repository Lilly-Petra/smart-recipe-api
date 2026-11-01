# Smart Recipe API

A .NET portfolio project for building a smart recipe-management API.

The long-term goal is to import a recipe from a public web-page URL, extract the relevant content, use AI to normalize it into structured data, validate the result, and store it in a database.

## Current status

The project currently contains a working in-memory CRUD API for recipes.

- Get all recipes
- Get a recipe by ID
- Create a recipe
- Update a recipe
- Delete a recipe
- Validate required recipe fields
- Test endpoints with a `.http` file directly in Visual Studio

## Current technologies

- C#
- ASP.NET Core Web API
- REST API
- Visual Studio
- Git and GitHub

## Current endpoints

| Method | Endpoint | Description |
| --- | --- | --- |
| GET | `/api/recipes` | Get all recipes |
| GET | `/api/recipes/{id}` | Get one recipe by ID |
| POST | `/api/recipes` | Create a recipe |
| PUT | `/api/recipes/{id}` | Update a recipe |
| DELETE | `/api/recipes/{id}` | Delete a recipe |

## Run the project

1. Open the solution in Visual Studio.
2. Press `F5`.
3. Send requests from `SmartRecipe.Api.http` or use the local API URL.

## Planned smart import flow

```text
Recipe URL
→ Read public recipe-page data
→ Extract recipe information
→ AI normalizes data into a structured recipe
→ Validate the result
→ Save the recipe to a database

##Planned features
- Entity Framework Core with SQLite
- Persistent recipe storage
- Ingredients, preparation steps, servings, and cooking time
- Source URL and import metadata
- POST /api/recipes/import endpoint
- Recipe extraction from public web pages
- AI-assisted recipe normalization
- Unit and integration tests

##Important limitation
Recipes are currently stored only in memory. All changes reset when the API stops.

The future AI import will preserve the original source URL and use AI to structure extracted information, not invent recipe data.