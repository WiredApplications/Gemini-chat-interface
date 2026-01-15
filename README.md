# GeminiChat – Intelligent Dialogue Desktop Application

A Windows Forms desktop application that enables users to interact with Google’s Gemini AI through a conversational interface, manage dialogue history, import/export conversations, and persist selected responses using a local SQLite database.

---

## Table of Contents
- [About](#about)
- [Getting Started](#getting-started)
- [Prerequisites](#prerequisites)
- [Features](#features)
- [Using the Gemini API](#using-the-gemini-api)
- [Data Management & SQLite Database](#data-management--sqlite-database)
- [Technologies Used](#technologies-used)
- [License](#license)

---

## About

**GeminiForms** is a desktop application developed in **C# using Windows Forms**

The purpose of this project is to design and implement an intelligent dialogue application that acts as an interface between the user and **Google’s Gemini AI model**.

The application allows users to submit questions, receive AI-generated responses, manage dialogue sessions, import and export text files, and store selected AI answers in a **local SQLite database** using an object-oriented design approach.

---

## Getting Started

The application can be executed locally using Visual Studio without special configuration beyond the required development tools and a valid Gemini API key.

---

## Prerequisites

Before opening or running the project, ensure the following are installed:

- Windows 10 or Windows 11
- Visual Studio 2022
- **.NET Desktop Development** workload
- .NET 8.0 (Windows) or compatible framework
- Internet connection (required for Gemini API communication)
- A valid **Google Gemini API Key**
- SQLite (included via NuGet packages)

---



## Features

- Communication with Google **Gemini AI** via API
- User question submission and AI-generated responses
- Continuous dialogue display 
- Clean and responsive Windows Forms interface
- Export:
  - Entire dialogue to `.txt`
  - Last AI response to `.txt`
- SQLite database integration for persistent storage
- Viewing saved responses in a separate window 


---

## Using the Gemini API

The application communicates with Google’s **Gemini API** to generate intelligent responses based on user input.

### API Communication
- User prompts are sent asynchronously to the Gemini API.
- Responses are returned in real time and displayed in the dialogue area.
- API interaction logic is encapsulated in dedicated service classes to ensure clean separation of concerns.


## Data Management & SQLite Database

The application uses a **local SQLite database** to store selected AI responses.

### Database Schema
The database contains a table with the following fields:

- **ID** (Primary Key)
- **Ημερομηνία** (DateTime)
- **Ερώτηση** (User Question)
- **Απάντηση** (AI Response)

### Database Features
- Save selected AI responses
- Persistent storage between sessions
- Basic CRUD operations implemented using an object-oriented approach

---

## Technologies Used

- C# (.NET 8.0 Windows)
- Windows Forms (WinForms)
- Google Gemini API
- SQLite (local database)
- System.Net.Http for API communication
- Newtonsoft.Json for JSON parsing
- ADO.NET / SQLite libraries

---


## License

This project is developed for **educational purposes**.

It is not intended for commercial use without explicit permission from the author.
