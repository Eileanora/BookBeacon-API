# BookBeacon-API

## Introduction
This project was done as a portfolio project for graduating from ALX Software Engineering program. Although it was originally done as a graduation project,
I loved working on it and I am planning to continue working on it for my love to books, reading and coding.

## What is BookBeacon?
BookBeacon is a web API project that imitates a library system.
Users can browse books, their authors, categories and publishers, available languages.

They can borrow a book for a specific duration, if there is a copy available. BookBeacon also provides a strict system where 
ill mannered users are not allowed to borrow books. It checks his late return count, notes on bad behavior, and after a certain threshold,
it bans the user from borrowing books.

## Technologies
- ASP.NET Core 8.0
- Entity Framework Core
- SQLServer
- Postman
- Swagger

## Libraries
- Fluent Validation
- Newtonsoft.Json
- Asp.Versioning.Mvc
- Microsoft.IdentityModel.JsonWebTokens (JWT)

## API Endpoints and their functionalities

### Book Endpoints
| Endpoint       | Method | Functionality                 |
|----------------|--------|-------------------------------|
| /api/v1/books            | GET    | Get all books                 |
| /api/v1/books/{id}       | GET    | Get a book by id              |
| /api/v1/books            | POST   | Add a new book                |
| /api/v1/books/{id}       | PATCH  | Update a book                 |
| /api/v1/books/{id}       | DELETE | Delete a book                 |

### Author Endpoints
| Endpoint       | Method | Functionality                 |
|----------------|--------|-------------------------------|
| /api/v1/authors          | GET    | Get all authors               |
| /api/v1/authors/{id}     | GET    | Get an author by id           |
| /api/v1/authors          | POST   | Add a new author              |
| /api/v1/authors/{id}     | PATCH  | Update an author              |
| /api/v1/authors/{id}     | DELETE | Delete an author              |

### Genre Endpoints
| Endpoint       | Method | Functionality                 |
|----------------|--------|-------------------------------|
| /api/v1/genres           | GET    | Get all genres                |
| /api/v1/genres/{id}      | GET    | Get a genre by id             |
| /api/v1/genres           | POST   | Add a new genre               |
| /api/v1/genres/{id}      | PATCH  | Update a genre                |
| /api/v1/genres/{id}      | DELETE | Delete a genre                |

### User Endpoints
| Endpoint       | Method | Functionality                 |
|----------------|--------|-------------------------------|
| /api/v1/users/register   | POST   | Register a new user           |
| /api/v1/users/login      | POST   | Login a user                  |
| /api/v1/users/info       | GET    | Get user info                 |

### Reservation Endpoints
| Endpoint       | Method | Functionality                 |
|----------------|--------|-------------------------------|
| /api/v1/reservations     | GET    | Get all reservations          |
| /api/v1/reservations/{id}| GET    | Get a reservation by id       |
| /api/v1/reservations     | POST   | Create a new reservation      |
| /api/v1/reservations/{id}| DELETE | Delete a reservation          |

### Copy Endpoints
| Endpoint       | Method | Functionality                 |
|----------------|--------|-------------------------------|
| /api/v1/copies           | GET    | Get all copies                |
| /api/v1/copies/{id}      | GET    | Get a copy by id              |
| /api/v1/copies           | POST   | Add a new copy                |
| /api/v1/copies/{id}      | PATCH  | Update a copy                 |
| /api/v1/copies/{id}      | DELETE | Delete a copy                 |



## Contributers
- [Yasmeen Hany](https://github.com/Eileanora)