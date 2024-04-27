using Microsoft.AspNetCore.Identity;
using System.Linq;
using userinfo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System;
namespace userinfo.Data
{
    public class Seed
 
        {
            public static void SeedData(IApplicationBuilder applicationBuilder)
            {
                using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                    context.Database.EnsureCreated();

                if (!context.Garages.Any())
                {
                    context.Garages.AddRange(new List<Garage>()
                    {
                        new Garage()
                        {
                            vin = "1HGCM82633A123456",
                            Make = "Honda",
                            Model = "Accord",
                            trim = "EX",
                            modelYear = "2003",
                            engineCylinders = "4",
                            displacementL = "2.4",
                            engineHP = "200",
                            driveType = "FWD",
                            Mileage = "10000",
                            purchaseDate = "01/01/2022",
                            nickname = "Nickname 1 Seed Data",
                        },
                        new Garage()
                        {
                            vin = "1HGCM82633A123456",
                            Make = "Honda",
                            Model = "Accord",
                            trim = "EX",
                            modelYear = "2003",
                            engineCylinders = "4",
                            displacementL = "2.4",
                            engineHP = "200",
                            driveType = "FWD",
                            Mileage = "10000",
                            purchaseDate = "01/01/2022",
                            nickname = "Nickname 1 Seed Data",
                        },
                        new Garage()
                        {
                            vin = "1HGCM82633A123456",
                            Make = "Honda",
                            Model = "Accord",
                            trim = "EX",
                            modelYear = "2003",
                            engineCylinders = "4",
                            displacementL = "2.4",
                            engineHP = "200",
                            driveType = "FWD",
                            Mileage = "10000",
                            purchaseDate = "01/01/2022",
                            nickname = "Nickname 2 Seed Data",
                        },
                        new Garage()
                        {
                            vin = "1HGCM82633A123456",
                            Make = "Honda",
                            Model = "Accord",
                            trim = "EX",
                            modelYear = "2003",
                            engineCylinders = "4",
                            displacementL = "2.4",
                            engineHP = "200",
                            driveType = "FWD",
                            Mileage = "10000",
                            purchaseDate = "01/01/2022",
                            nickname = "Nickname 3 Seed Data",
                        } });
                        context.SaveChanges();
                    }
                    //Races
                    if (!context.Servicelogs.Any())
                    {
                        context.Servicelogs.AddRange(new List<Servicelog>()
                    {
                        new Servicelog()
                        {
                            date = DateTime.Now,
                            mileageIn = "10000",
                            mileageOut = "10500",
                            serviceNotes = "Service notes for log 1",
                            vehicleId = 1,

                        },
                        new Servicelog()
                        {
                            date = DateTime.Now,
                            mileageIn = "10000",
                            mileageOut = "10500",
                            serviceNotes = "Service notes for log 1",
                            vehicleId = 2,

                        },
                        new Servicelog()
                        {
                            date = DateTime.Now,
                            mileageIn = "10000",
                            mileageOut = "10500",
                            serviceNotes = "Service notes for log 1",
                            vehicleId = 3,

                        }
                    });
                        context.SaveChanges();
                    }
                }
            }

            public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
            {
                using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
                {
                    //Roles
                    var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                    if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                        await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                    if (!await roleManager.RoleExistsAsync(UserRoles.User))
                        await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                    //Users
                    var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                    string adminUserEmail = "flcac3@gmail.com";

                    var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                    if (adminUser == null)
                    {
                        var newAdminUser = new User()
                        {
                            UserName = "charlesdev",
                            Email = adminUserEmail,
                            EmailConfirmed = true,
                        };
                        await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                        await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                    }

                    string appUserEmail = "user@etickets.com";

                    var appUser = await userManager.FindByEmailAsync(appUserEmail);
                    if (appUser == null)
                    {
                        var newAppUser = new User()
                        {
                            UserName = "app-user",
                            Email = appUserEmail,
                            EmailConfirmed = true,
                        };
                        await userManager.CreateAsync(newAppUser, "Coding@1234?");
                        await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                    }
                }
            }
        }
    }

