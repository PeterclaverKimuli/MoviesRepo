using AppAPI.Core.Interfaces;
using AppAPI.Core.Models;
using AppAPI.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Persistence
{
    public class MovieRepositoryTest
    {
        private readonly DbContextOptions<AppDbContext> options;

        public MovieRepositoryTest()
        {
            options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite("Filename=Test.db").Options;
            Seed();
        }

        [Fact]
        public async Task AddShouldAddMovie()
        {
            using (var context = new AppDbContext(options))
            {
                //Arrange
                IMovieRepository movieRepository = new MovieRepository(context);
                IUnitOfWork unitOfWork = new UnitOfWork(context);

                Movie movie = new Movie
                {
                    Id = 3,
                    Name = "Batman",
                    DateAdded = DateTime.Now,
                    ReleaseDate = DateTime.Parse("2015-06-04"),
                    NumberInStock = 2,
                    GenreId = 1
                };

                //Act
                await movieRepository.Add(movie);
                await unitOfWork.Complete();

            }

            using (var context = new AppDbContext(options))
            {
                //Assert
                var movie = await context.Movies.SingleOrDefaultAsync(m => m.Name == "Batman");

                Assert.NotNull(movie);
                Assert.Equal("Batman", movie.Name);
            }
        }

        [Fact]
        public async Task GetMovieShouldReturnAMovie()
        {
            using(var context = new AppDbContext(options))
            {
                //Arrange
                IMovieRepository movieRepository = new MovieRepository(context);

                //Act 
                var movie = await movieRepository.GetMovie(1);

                //Assert
                Assert.NotNull(movie);
                Assert.Equal("Joker", movie.Name);
            }
        }

        [Fact]
        public async Task RemoveShouldRemoveAMovie()
        {
            using (var context = new AppDbContext(options))
            {
                //Arrange
                IMovieRepository movieRepository = new MovieRepository(context);
                IUnitOfWork unitOfWork = new UnitOfWork(context);

                var movie = new Movie
                {
                    Id = 2,
                    Name = "Cappy",
                    DateAdded = DateTime.Now,
                    ReleaseDate = DateTime.Parse("2002-05-04"),
                    NumberInStock = 5,
                    GenreId = 1
                };

                //Act
                movieRepository.Remove(movie);
                await unitOfWork.Complete();

                //Assert
                var removedMovie = context.Movies.SingleOrDefault(m => m.Id == 2);

                Assert.Null(removedMovie);
            }
        }

        private void Seed()
        {
            using(var context = new AppDbContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Movies.AddRange(
                    new Movie{ 
                        Id = 1,
                        Name = "Joker",
                        DateAdded = DateTime.Now,
                        ReleaseDate = DateTime.Parse("2019-05-04"),
                        NumberInStock = 2,
                        GenreId = 1
                    },
                    new Movie
                    {
                        Id = 2,
                        Name = "Cappy",
                        DateAdded = DateTime.Now,
                        ReleaseDate = DateTime.Parse("2002-05-04"),
                        NumberInStock = 5,
                        GenreId = 1
                    }
                );

                context.Genres.Add(
                    new Genre{
                        Id = 1,
                        Name = "Action"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
