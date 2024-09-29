# BlogBuzz
BlogBuzz is a dynamic blog application that allows users to explore and share blogs related to the latest technologies, tutorials, and development articles. Built with ASP.NET Core for the backend and a responsive frontend, BlogBuzz offers an intuitive and engaging user experience.

### Features
User Authentication: Secure login and registration for users.

- Blog Creation and Editing: Users can write, edit, and publish their blogs.
- Comment System: Engage with blog posts through a comment section.
- Search Functionality: Find specific blogs by keywords or categories.
- Categories and Tags: Organize blog posts with categories and tags for better discoverability.
- Admin Dashboard: Manage blogs, comments, and users from an admin interface.
- Likes: Logged-users can like the blog posts
- User categories: Three levels of user categories:
  - User
  - Admin
  - SuperAdmin

### Screenshots
- Home page
![image](https://github.com/user-attachments/assets/ec2c25b0-504a-45a6-8ae4-78e6ef8e080f)
- Blogs
![image](https://github.com/user-attachments/assets/07f3dc3c-0549-498d-93f4-07f20887132f)
- Blog Post
![image](https://github.com/user-attachments/assets/10734fff-ee15-46de-9273-13e40de4c561)

### Tech Stack
#### Frontend:
- HTML, CSS, JavaScript
- Bootstrap for responsive design
#### Backend:
- ASP.NET Core MVC
- Entity Framework Core for database operations
#### Database:
- Microsoft SQL Server
#### Authentication:
- ASP.NET Identity for secure user authentication
#### Version Control:
- GitHub for source control and project collaboration


### How to Run the Project
#### Clone the repository:

```
git clone https://github.com/JoelVStan/BlogBuzz-DotNet.git
cd BlogBuzz-DotNet
```
#### Configure the Database:
Update the connection string in appsettings.json to point to your local SQL Server instance.
#### Apply Migrations:
```
dotnet ef database update
```
#### Run the application:
```
dotnet run
```
Open your browser and navigate to http://localhost:5000.

### Project Structure
- Models/: Contains the data models used by Entity Framework Core.
- Views/: Contains the Razor Views (UI templates) for different pages.
- Controllers/: Handles HTTP requests and connects the views with models.
- wwwroot/: Static files like CSS, JavaScript, and images.

### Contributions
Contributions are welcome! Feel free to submit issues or pull requests for any improvements or feature suggestions.
