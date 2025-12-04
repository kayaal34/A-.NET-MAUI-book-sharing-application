# SelfShare - Book Exchange App

A .NET MAUI cross-platform mobile application for university students to exchange textbooks with each other.

## About

SelfShare is designed to help students share and exchange textbooks within their university community. Students can list their available books, browse books from other students, and arrange exchanges to save money on expensive textbooks.

**Developed by students from Ural Federal University**

## Technology Stack

- .NET 8
- .NET MAUI (Multi-platform App UI)
- C# 12.0
- XAML

## How to Run

### Prerequisites
- Visual Studio 2022 (17.8 or later)
- .NET 8.0 SDK
- MAUI workloads installed

### Installation & Running

1. Clone the repository:
```bash
git clone https://github.com/kayaal34/A-.NET-MAUI-book-sharing-application.git
cd A-.NET-MAUI-book-sharing-application
```

2. Navigate to project directory:
```bash
cd SelfShare
```

3. Restore dependencies:
```bash
dotnet restore
```

4. Build and run:
```bash
# For Windows (recommended)
dotnet run --framework net8.0-windows10.0.19041.0

# For Android
dotnet run --framework net8.0-android
```

## Current Features

- Welcome screen with app introduction
- User registration and login interface
- User profile management
- Basic book listing structure
- Cross-platform navigation

## Project Structure

```
SelfShare/
??? Views/                    # Application pages
??? Resources/Images/         # App icons and images
??? Resources/Styles/         # UI themes
??? AppShell.xaml            # Navigation structure
```

## Development Status

This project is currently in active development. Core UI components are implemented, with backend integration planned for future releases.

## Contact

Repository: https://github.com/kayaal34/A-.NET-MAUI-book-sharing-application

---

**Made with ?? using .NET MAUI**