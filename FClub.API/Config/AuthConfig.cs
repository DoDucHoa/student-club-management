﻿using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FClub.API.Config
{
    public static class AuthConfig
    {
        public static void ConfigFirebaseAuth(this IServiceCollection services)
        {
            string startupPath = Environment.CurrentDirectory;
            string realPath = startupPath + @"\auth-club-management-dev-firebase-adminsdk-j4jta-9138e37c11.json";
            //Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "auth-club-management-dev-firebase-adminsdk-j4jta-9138e37c11.json");
            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile(realPath),
                //Credential = GoogleCredential.GetApplicationDefault(),
            });
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    //options.Authority = "https://securetoken.google.com/tutor-helper-6faa2";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ClockSkew = TimeSpan.Zero,
                        ValidateIssuer = false,
                        //ValidIssuer = "https://securetoken.google.com/tutor-helper-6faa2",
                        ValidateAudience = false,
                        //ValidAudience = "tutor-helper-6faa2",
                        //ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
                    };
                });
        }
    }
}
