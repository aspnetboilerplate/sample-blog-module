# sample-blog-module
A Sample blog module built on ABP and module-zero. __src__ folder contains the sample blog module. __app__ folder contains an application uses the blog module.

## Nuget packages for blog module
* https://www.nuget.org/packages/Abp.Samples.Blog.Core
* https://www.nuget.org/packages/Abp.Samples.Blog.EntityFramework
* https://www.nuget.org/packages/Abp.Samples.Blog.Application
* https://www.nuget.org/packages/Abp.Samples.Blog.Web

## How to install

__app__ folder contains an application that installed the blog module. If you just want to test it, you can download it and skip to "Run migrations" section.

### Create your project
Create an "ABP + module zero" project template from http://www.aspnetboilerplate.com/Templates. If you have a created project, skip this step.

### Install nuget packages
Blog module actually consists of 4 sub-module: Core (domain) layer, EntityFramework infrastructure, Application layer and Web (presentation) layer. Install each package to appropriate projects in your solution:

* Abp.Samples.Blog.Core to your .Core project (OPTIONAL).
* Abp.Samples.Blog.EntityFramework to your .EntityFramework project (OPTIONAL).
* Abp.Samples.Blog.Application to your application project (OPTIONAL).
* All (Abp.Samples.Blog.Core, Abp.Samples.Blog.EntityFramework, Abp.Samples.Blog.Application, Abp.Samples.Blog.Web) to your .Web project.

Note: OPTIONAL steps are not required in order to run web application. For example, you should add Abp.Samples.Blog.Core to your .Core project only if you want to directly use Blog entities in your domain layer.

### Add module dependencies
* Add [DependsOn(typeof(AbpSampleBlogCoreModule))] for your Core module/project (OPTIONAL).
* Add [DependsOn(typeof(AbpSampleBlogApplicationModule))] for your Application module/project (OPTIONAL).
* Add [DependsOn(typeof(AbpSampleBlogEntityFrameworkModule))] for your EntityFramework module/project (OPTIONAL).
* Add [DependsOn(typeof(AbpSampleBlogWebModule), typeof(AbpSampleBlogEntityFrameworkModule))] for your Web module/project.

Bote: OPTIONAL steps are not required in order to run web application. These dependencies just force initialize orders of modules.

### Run migrations
Run EntityFramework migrations to create database schema for blog module.

To run migrations from command line, we first create an empty folder, copy all files from "packages\EntityFramework.6.1.3\tools" to this new folder. Also, copy all files from "MyAbpZeroProject.Web\bin" (project should be built in Debug once) to this new folder (EF version or project name may be different for your case). Then we can use migrate.exe to update database:

<pre>migrate.exe Abp.Samples.Blog.EntityFramework.dll /connectionString="Server=localhost;Database=YOUR_DATABASE;User=sa;Password=YOUR_PASSWORD;" /connectionProviderName="System.Data.SqlClient"</pre>

Note that, from now we have 2 different migrations: One for our application and one for blog module. We first run our own migrations since blog module requires AspNet Zero tables exist in the database.

### Run the application

After these steps, we can run the application. After login, we see that a new menu item called 'Blog' added to the main menu. We can click it to enter admin page for the blog.

### Notes
This module is developed to be a sample for module development. It's pretty new and there is no much functionality for now.
