# Xpose Wallet

Xpose Wallet should be a web-based application built with C# and .NET 8, designed around a hosted frontend and a locally running backend.

CURRENT PLAN FOR FUTURE:
--
## Architecture

- **Hosted Website:** Provides the main user interface.
- **Local Backend:** A C# application running on the user's computer.
- **Communication:** The website communicates with the local backend through HTTP requests and JSON.
- **Local Processing:** The backend handles application logic and local operations.

## How It Works

1. The user opens the hosted website.
2. The website checks whether the local Xpose Wallet backend is running.
3. If the backend is unavailable, backend-dependent features remain inaccessible.
4. If the backend is running, the website communicates with it through `localhost:8080`.
5. The backend processes requests and returns responses.

## Technologies

- C#
- .NET 8
- HTML, CSS, JavaScript
- `HttpListener`
- HTTP and JSON

## Development Status

**Xpose Wallet is currently in development and at a very early stage.** Its architecture and features are still being built and may change over time.

Development follows two core principles:

- **YAGNI (You Aren't Gonna Need It)
- **KISS (Keep It Simple, Stupid)

The focus is on building a functional foundation first and expanding the application only when needed.

