This is a full-stack application built with .NET Core API 8 for the backend and Angular 17 standalone components for the frontend

## Running the Application

### Prerequisites
- .NET Core SDK 8
- Node.js and npm
- Angular CLI

### Backend (API)
1. Navigate to the `backend` directory.
2. Run `dotnet build` to build the project.
3. Run `dotnet run` to start the API server.

The API server should now be running on `https://localhost:7107/swagger/index.html`.

### Frontend
1. Navigate to the `frontend` directory.
2. Run `npm install` to install dependencies.
3. Run `ng serve -o` to start the Angular development server.

The frontend should now be accessible at `http://localhost:4200`.

## API Key Authentication

The backend API utilizes API key authentication for accessing protected endpoints. To interact with the API, you need to provide an API key in the request headers.

### Setting the API Key
1. In the frontend application, there will be an input field to enter the API key.
2. Enter the API key: `123456` in the input field and click the "Identify" button.
3. The frontend will display a list of notes from server. All other Crud functions work normally from here.
