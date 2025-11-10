# Appdev-mvc
A simple blog application featuring the MVC software architecture.

## How to Run This Project

1. **Install .NET SDK**
	- Make sure you have the .NET 8.0 (or later) SDK installed. You can download it from https://dotnet.microsoft.com/download

2. **Restore Dependencies**
	- Open a terminal in the project root directory and run:
	  ```sh
	  dotnet restore
	  ```

3. **Run the Application (with Hot Reload)**
	- For automatic reload on code changes, use:
	  ```sh
	  dotnet watch run
	  ```
	- Or, to run normally:
	  ```sh
	  dotnet run
	  ```

4. **Open in Browser**
	- By default, the app will be available at `https://localhost:5001` or `http://localhost:5000`.

5. **Stop the App**
	- Press `Ctrl+C` in the terminal to stop the server.

---
If you encounter issues, ensure your .NET SDK is up to date and you are in the correct directory (where `BlogApp.csproj` is located).