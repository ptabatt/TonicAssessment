# Tonic Assessment Project

## Overview

This project is part of the Tonic assessment and is designed to showcase a simple console application for managing a todo list. 
It utilizes .NET and Entity Framework Core for data persistence.

## Project Structure

The project structure is organized as follows:

- **TonicTodoList.Console**: For now, this is all that exists in the github repository. This includes the data, the data access layer, and the core logic such as the repository.
- **TonicTodoList.Test**: I ran into some bizarre, unexpected issues pushing my test project. You can find the gist here: https://gist.github.com/ptabatt/5d4c87d4b2ff388d219523b0c809e720


## Prerequisites

- .NET 7.0 or later
- SQLite database (used by default)

## Getting Started

1. Clone the repository:

    ```bash
    git clone https://github.com/yourusername/tonic-assessment.git
    ```

2. Navigate to the project directory:

    ```bash
    cd tonic-assessment
    ```

3. Build the solution:

    ```bash
    dotnet build
    ```

4. Run the console application:

    ```bash
    dotnet run --project TonicTodoList.Console
    ```

## Database Setup

The project uses Entity Framework Core with SQLite by default. To create and apply the initial database migration, run the following commands:

```bash
dotnet ef migrations add InitialCreate --project TonicTodoList.Data
dotnet ef database update --project TonicTodoList.Data
