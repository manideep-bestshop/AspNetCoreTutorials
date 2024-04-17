                                Authentication And Authorization
                                --------------------------------
Authentication
Authentication is like showing your ID to prove who you are. For example , when we buy the tickets in PVR cinemas , At the entrance they will ask to show ticket(authentication) , if we show tickets they will allow.
Authentication  typically involves the use of usernames, passwords, biometric data (fingerprints or facial recognition), security tokens
Authorization
Authorization is like being granted access to certain areas or activities based on your ID. For example , after showing the ticket they allow us to cinemas area there are multiple auditoriums ,then authorization determines to what auditorium you are allowed to watch movie.
Authorization in involve role-based access control
Authentication and authorization are important to maintaining the security to system and data.
There are different types of authentications, Here I took token based example
JWT Authentication

JWT (JSON Web Token) authentication is a method used to verify the identity of users.
For example , when you book a bike on Uber app it generates OTP(token) , if you share the OTP with allotted rider, the rider will allow you to sit on bike and drop you at your destination.
Here we can see process of Implementing of JWT authentication in Web API Project step by step,
1. Add ASP.Net Core API Application
Open visual studio 2022 click on create new project --> Select ASP.Net Core Web API --> Next

Give desired project and solution name --> Next --> select framework .Net 8.0 --> Create
2. Add Nuget Packages 
Add the following packages from nuget package manager.
•	Microsoft.AspNetCore.Authentication.JwtBearer
•	Microsoft.IdentityModel.Tokens
•	System.IdentityModel.Tokens.Jwt

3. Add setting in appsetting.json
Open appsetting.json and add following Key, Issuer and Audience
 
4. Register JWT token for Authentication in Program.cs file
 


5. Create Models (UserModel )
Add a new folder with Models name and create  UserModel 
 
6. Create LoginAPI Controller (Authenticate user and generate token)
Add a new Empty API controller name “LoginController” in controller folder.
 
Here creates one Post Action method for Login and two methods for Authenticating the user credentials and Generates the token (if user is authenticated).
 
 
 
 
7. Create Web API project with Product controller  to authorize getting Product Details 
. Add Nuget Packages 
Add the following packages from nuget package manager.
•	Microsoft.AspNetCore.Authentication.JwtBearer
•	Microsoft.IdentityModel.Tokens
•	System.IdentityModel.Tokens.Jwt


Create get method to get product list
 

add jwt authentication in program.cs and key in appsettings.json
 
 
8. Test the API endpoint in Postman with Token
Run the application and 
 give the value of Username and Password
 
Copy the url paste in postman and copy the token and paste in bearer token
 
Summary

So I explained what is authentication and authorization and jwt token and How to create jwt authentication and how to generate token

                                                                Thank You






