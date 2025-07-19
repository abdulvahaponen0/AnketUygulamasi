📊 Survey Application API (AnketUygulamasiAPI)
A RESTful Web API for creating, managing, and participating in surveys. Built using ASP.NET Core with Entity Framework Core and SQL Server for data storage.

✨ Features
📝 Create, read, update, and delete surveys and their questions

❓ Support for multiple question types (e.g., multiple choice, text input)

📥 User responses management and validation

🔄 RESTful API design principles applied

✅ Unit tests with xUnit and Moq for key components

🗄️ Database migrations with EF Core

🛠️ Technologies Used
⚙️ ASP.NET Core Web API

🗃️ Entity Framework Core

🖥️ SQL Server

🧪 xUnit, Moq (for unit testing)

🚀 Getting Started
📋 Prerequisites
.NET SDK 6.0 or later

SQL Server (local or remote instance)

📥 Installation
Clone the repository:

bash
Kopyala
Düzenle
git clone https://github.com/avonen22/AnketUygulamasi.git
Configure the connection string in appsettings.json to point to your SQL Server instance.

Apply database migrations:

bash
Kopyala
Düzenle
dotnet ef database update
Run the application:

bash
Kopyala
Düzenle
dotnet run
The API will be available at https://localhost:{port}/api

📡 API Endpoints
/api/surveys - Manage surveys

/api/questions - Manage questions related to surveys

/api/responses - Submit and retrieve user responses

(You can expand this section with specific request/response examples.)

🧪 Testing
Run unit tests using the following command:

bash
Kopyala
Düzenle
dotnet test
🤝 Contributing
Feel free to fork the repository and submit pull requests. For major changes, please open an issue first to discuss what you would like to change.

📄 License
This project is licensed under the MIT License.
