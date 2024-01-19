using Microsoft.AspNetCore.Identity;
using NTier_ECommerce_Entities;
using NTier_ECommerce_Entities.Enum;
using NTier_ECommerce_Entities.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier_ECommerce_DAL.Database
{
    public class AddDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<Context>();

                context.Database.EnsureCreated();

                // Cinema
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Cinema 1",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 2",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 3",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 4",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 5",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                    });
                    context.SaveChanges();
                }
                // Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actors>()
                    {
                        new Actors()
                        {
                            NameSurname = "Actor 1",
                            Biography = "This is the Bio of the first actor",
                            ProfileUrl = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Actors()
                        {
                            NameSurname = "Actor 2",
                            Biography = "This is the Bio of the second actor",
                            ProfileUrl = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actors()
                        {
                            NameSurname = "Actor 3",
                            Biography = "This is the Bio of the second actor",
                            ProfileUrl = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actors()
                        {
                            NameSurname = "Actor 4",
                            Biography = "This is the Bio of the second actor",
                            ProfileUrl = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Actors()
                        {
                            NameSurname = "Actor 5",
                            Biography = "This is the Bio of the second actor",
                            ProfileUrl = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            NameSurname = "Producer 1",
                            Biography = "This is the Bio of the first actor",
                            ProfileUrl = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new Producer()
                        {
                            NameSurname = "Producer 2",
                            Biography = "This is the Bio of the second actor",
                            ProfileUrl = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Producer()
                        {
                            NameSurname = "Producer 3",
                            Biography = "This is the Bio of the second actor",
                            ProfileUrl = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Producer()
                        {
                            NameSurname = "Producer 4",
                            Biography = "This is the Bio of the second actor",
                            ProfileUrl = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Producer()
                        {
                            NameSurname = "Producer 5",
                            Biography = "This is the Bio of the second actor",
                            ProfileUrl = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            MovieName = "Life",
                            MovieDescription = "This is the Life movie description",
                            Price = 39.50,
                            MovieImageUrl = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartingDate = DateTime.Now.AddDays(-10),
                            EndingDate = DateTime.Now.AddDays(10),
                            CinemaId = 3,
                            ProducerId = 3,
                            CategoryMovie = CategoryMovie.Documentary
                        },
                        new Movie()
                        {
                            MovieName = "The Shawshank Redemption",
                            MovieDescription = "This is the Shawshank Redemption description",
                            Price = 29.50,
                            MovieImageUrl = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            StartingDate = DateTime.Now,
                            EndingDate = DateTime.Now.AddDays(3),
                            CinemaId = 1,
                            ProducerId = 1,
                            CategoryMovie = CategoryMovie.Action
                        },
                        new Movie()
                        {
                            MovieName = "Ghost",
                            MovieDescription = "This is the Ghost movie description",
                            Price = 39.50,
                            MovieImageUrl = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartingDate = DateTime.Now,
                            EndingDate = DateTime.Now.AddDays(7),
                            CinemaId = 4,
                            ProducerId = 4,
                            CategoryMovie = CategoryMovie.Horror
                        },
                        new Movie()
                        {
                            MovieName = "Race",
                            MovieDescription = "This is the Race movie description",
                            Price = 39.50,
                            MovieImageUrl = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            StartingDate = DateTime.Now.AddDays(-10),
                            EndingDate = DateTime.Now.AddDays(-5),
                            CinemaId = 1,
                            ProducerId = 2,
                            CategoryMovie = CategoryMovie.Documentary
                        },
                        new Movie()
                        {
                            MovieName = "Scoob",
                            MovieDescription = "This is the Scoob movie description",
                            Price = 39.50,
                            MovieImageUrl = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            StartingDate = DateTime.Now.AddDays(-10),
                            EndingDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            ProducerId = 3,
                            CategoryMovie = CategoryMovie.Cartoon
                        },
                        new Movie()
                        {
                            MovieName = "Cold Soles",
                            MovieDescription = "This is the Cold Soles movie description",
                            Price = 39.50,
                            MovieImageUrl = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            StartingDate = DateTime.Now.AddDays(3),
                            EndingDate = DateTime.Now.AddDays(20),
                            CinemaId = 1,
                            ProducerId = 5,
                            CategoryMovie = CategoryMovie.Drama
                        }
                    });
                    context.SaveChanges();
                }
                //Actors & Movies
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actors_Movie>()
                    {
                        new Actors_Movie()
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        new Actors_Movie()
                        {
                            ActorId = 3,
                            MovieId = 1
                        },

                         new Actors_Movie()
                        {
                            ActorId = 1,
                            MovieId = 2
                         },
                         new Actors_Movie()
                        {
                            ActorId = 4,
                            MovieId = 2
                         },

                        new Actors_Movie()
                        {
                            ActorId = 1,
                            MovieId = 3
                        },
                        new Actors_Movie()
                        {
                            ActorId = 2,
                            MovieId = 3
                        },
                        new Actors_Movie()
                        {
                            ActorId = 5,
                            MovieId = 3
                        },


                        new Actors_Movie()
                        {
                            ActorId = 2,
                            MovieId = 4
                        },
                        new Actors_Movie()
                        {
                            ActorId = 3,
                            MovieId = 4
                        },
                        new Actors_Movie()
                        {
                            ActorId = 4,
                            MovieId = 4
                        },


                        new Actors_Movie()
                        {
                            ActorId = 2,
                            MovieId = 5
                        },
                        new Actors_Movie()
                        {
                            ActorId = 3,
                            MovieId = 5
                        },
                        new Actors_Movie()
                        {
                            ActorId = 4,
                            MovieId = 5
                        },
                        new Actors_Movie()
                        {
                            ActorId = 5,
                            MovieId = 5
                        },


                        new Actors_Movie()
                        {
                            ActorId = 3,
                            MovieId = 6
                        },
                        new Actors_Movie()
                        {
                            ActorId = 4,
                            MovieId = 6
                        },
                        new Actors_Movie()
                        {
                            ActorId = 5,
                            MovieId = 6
                        },
                    });
                    context.SaveChanges();
                }
            }

            #region EXPLANATION 
            /* Seed method => This method adds startup data to the database when the application is run for the first time.
             * The CreateScope method creates a service scope provided by Dependency Injection. This scope is used to perform operations within this method.
             * Context class is obtained with the GetService method. This represents the DbContext that will be used to access the database and insert data.
             * The EnsureCreated method checks whether the database has been created or not. If the database has not been created yet, it creates it.
             * ** Adding Initial Data to the Cinema, Actors, Producers, Movies, and Actors_Movies Tables:
                 These parts insert the initial data into these tables if the corresponding table is empty. Sample data is included for each table.
             * The SaveChanges method saves the changes made to the database. This method is called when data is added for each table and changes occur.
             */
            #endregion

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
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@etickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
