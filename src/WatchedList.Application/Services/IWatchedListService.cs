﻿using WatchedList.Domain.Entities;

namespace WatchedList.Application.Services;

/// <summary>
/// Contract for the WatchedList service to be implemented in the Application layer.
/// </summary>
public interface IWatchedListService
{
    Task<int> AddMovieAsync(Movie movie);
    Task<int> AddRatingAsync(Rating rating);
    Task<int> AddTheatricalPerformanceAsync(TheatricalPerformance theatricalPerformance);
    Task<int> AddTvShowAsync(TvShow tvShow);
    Task<int> DeleteMovieAsync(Guid id);
    Task<int> DeleteTheatricalPerformanceAsync(Guid id);
    Task<int> DeleteTvShowAsync(Guid id);
    Task<Movie?> GetMovieAsync(Guid id);
    Task<List<Movie>> GetMoviesAsync();
    Task<Rating?> GetRatingAsync(int id);
    Task<Rating?> GetRatingAsync(string name);
    Task<List<Rating>> GetRatingsAsync();
    Task<TheatricalPerformance?> GetTheatricalPerformanceAsync(Guid id);
    Task<List<TheatricalPerformance>> GetTheatricalPerformancesAsync();
    Task<TvShow?> GetTvShowAsync(Guid id);
    Task<List<TvShow>> GetTvShowsAsync();
    Task<int> UpdateMovieAsync(Movie movie);
    Task<int> UpdateTheatricalPerformanceAsync(TheatricalPerformance theatricalPerformance);
    Task<int> UpdateTvShowAsync(TvShow tvShow);
}