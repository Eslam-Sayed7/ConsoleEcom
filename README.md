# ConsoleEcomm

A simple C# console-based e-commerce application with support for products, carts, orders, and shipping.

## Features

- Customer creation and management
- Product catalog with shippable and expirable products
- Cart and order management
- Shipping calculation and processing

## Project Structure

- `Domain/` - Core business logic and models
- `DataAccess/` - Data storage and repository implementations
- `UI/` - Console user interface and entry point

## Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- [Docker](https://www.docker.com/) (optional, for containerization)

## Building and Running Locally

1. Clone the repository:
   ```sh
   git clone https://github.com/yourusername/ConsoleEcomm.git
   cd ConsoleEcomm
   ```
## To run the container for your project, follow these steps:

1. **Build the Docker image** (from the project root, where `ConsoleEcomm.sln` is located):
   ```sh
   docker build -f UI/Dockerfile -t consoleecomm .
   ```

2. **Run the container**:
   ```sh
   docker run -it --name EslamConsoleEcomm consoleecomm:latest
   ```
