# SelfShare - Book Exchange App

A .NET MAUI cross-platform mobile application for students to exchange books with each other.

## Features

- ?? Browse available books
- ? Add your books to share
- ?? User authentication (Login/SignUp)
- ?? Book exchange requests
- ?? User profiles
- ?? Cross-platform (Android, iOS, Windows, macOS)

## Technology Stack

- **.NET 8**
- **.NET MAUI** (Multi-platform App UI)
- **C# 12.0**
- **XAML** for UI design

## Project Structure

```
SelfShare/
??? Views/
?   ??? WelcomePage.xaml      # Welcome/landing page
?   ??? LoginPage.xaml        # User login
?   ??? SignUpPage.xaml       # User registration
?   ??? HomePage.xaml         # Main home screen
?   ??? AddBookPage.xaml      # Add new books
?   ??? ProfilePage.xaml      # User profile & book management
??? Resources/
?   ??? Images/               # App images and icons
?   ??? Fonts/                # Custom fonts
?   ??? Styles/               # App themes and styles
??? AppShell.xaml            # App navigation structure
```

## Screenshots

*Screenshots will be added soon*

## Getting Started

### Prerequisites

- Visual Studio 2022 (17.8 or later)
- .NET 8.0 SDK
- MAUI workloads installed

### Installation

1. Clone the repository:
```bash
git clone https://github.com/[YourUsername]/SelfShare.git
cd SelfShare
```

2. Restore dependencies:
```bash
dotnet restore
```

3. Build the project:
```bash
dotnet build
```

4. Run the application:
```bash
# For Windows
dotnet run --framework net8.0-windows10.0.19041.0

# For Android
dotnet run --framework net8.0-android

# For iOS (Mac only)
dotnet run --framework net8.0-ios
```

## Development Status

?? **Current Status**: Active Development

### Completed Features
- ? Welcome page with app branding
- ? User authentication (Login/SignUp) UI
- ? Profile page with user stats
- ? Basic navigation structure
- ? Responsive UI design

### Upcoming Features
- ?? Backend integration
- ?? Book database and search
- ?? Real user authentication
- ?? Push notifications
- ?? Chat/messaging system

## Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact

Project Link: [https://github.com/[YourUsername]/SelfShare](https://github.com/[YourUsername]/SelfShare)

---

**Made with ?? using .NET MAUI**