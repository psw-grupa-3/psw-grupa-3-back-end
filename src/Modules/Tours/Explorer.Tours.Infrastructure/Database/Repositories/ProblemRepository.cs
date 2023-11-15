
﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Dtos.Tours;
using Explorer.Tours.Core.Converters;
using Explorer.Tours.Core.Domain.Order;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Tours;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

﻿using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Tours.API.Dtos.Tours;
using Explorer.Tours.Core.Converters;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Tours;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;
using System.Text.Json.Nodes;


namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class ProblemRepository : CrudDatabaseRepository<Problem, ToursContext>, IProblemRepository
    {

        private readonly ToursContext _context;
        private readonly DbSet<DbEntity<Problem>> _dbSet;
        public ProblemRepository(ToursContext dbContext) : base(dbContext)
        {
            _context = dbContext;
            _dbSet = DbContext.Set<DbEntity<Problem>>();
        }


        public ProblemDto GetProblemById(long id)
        {
            var dbProblem = _dbSet.Find(id);

            if (dbProblem != null)
            {
                string json = dbProblem.JsonObject; // pretpostavka da je svojstvo JsonObject u dbProblem
                Problem problem = JsonConvert.DeserializeObject<Problem>(json);
                ProblemDto dto= problem.ToDto();
                return dto;
            }

            return null;
        }
     





        public static Problem ExtractProblem(string jsonString)
        {
            jsonString = jsonString.Trim();

            if (jsonString.StartsWith("{") && jsonString.EndsWith("}"))
            {
                jsonString = jsonString.Substring(1, jsonString.Length - 2);
            }

            string[] propertyPairs = jsonString.Split(',');

            var properties = new Dictionary<string, string>();

            foreach (var propertyPair in propertyPairs)
            {
                int colonIndex = propertyPair.LastIndexOf(':');

                if (colonIndex == -1)
                {
                    throw new ArgumentException($"Invalid property pair: {propertyPair}");
                }

                string key = propertyPair.Substring(0, colonIndex).Trim().Trim('"');
                string value = propertyPair.Substring(colonIndex + 1).Trim().Trim('"');

                properties[key] = value;
            }

            var time = properties.ContainsKey("Time") ? ParseDateTime(properties["Time"]) : DateTime.MinValue;
            var deadline = properties.ContainsKey("Deadline") ? ParseDateTime(properties["Deadline"]) : DateTime.MinValue;

            var problem = new Problem
            (
                 long.Parse(properties["Id"]),
                    properties["Category"],
                    bool.Parse(properties["Priority"]),
                    properties["Description"],
                    time,
                    long.Parse(properties["TourId"]),
                    int.Parse(properties["TouristId"]),
                    properties["AuthorsSolution"],
                    bool.Parse(properties["IsSolved"]),
                    properties["UnsolvedProblemComment"],
                    deadline
            );

            return problem;
        }


        private static DateTime ParseDateTime(string dateTimeString)
        {
            if (DateTime.TryParse(dateTimeString, out DateTime result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException($"Invalid DateTime format: {dateTimeString}");
            }
        }

        public int GetProblemCount()
        {

            var problems = _context.Problems.ToList();
            var last = problems.LastOrDefault();
            if( last == null)
            {
                return 1;
            }
            else
            {
                return (int)last.Id;
            }

            return _dbSet.Count();

        }
        public List<ProblemDto> GetUnresolvedProblemsWithDeadline(List<ProblemDto> problems)
        {
            return problems
                .Where(problem => !problem.IsSolved && problem.Deadline < problem.Time)
                .ToList();
        }
        public List<ProblemDto> GetAllProblems()
        {
            var dbProblems = _context.Problems.ToList();
            List<ProblemDto> problemDtos = new List<ProblemDto>();

            foreach (var dbProblem in dbProblems)
            {
                var problem = JsonConvert.DeserializeObject<Problem>(dbProblem.JsonObject);
                var dto = ProblemConverter.ToDto(problem);
                dto.Id = dbProblem.Id;
               


                problemDtos.Add(dto);
            }

            return problemDtos
                .Where(problem => !problem.IsSolved && problem.Deadline < problem.Time)
                .ToList(); return problemDtos;
        }
        public List<ProblemDto> GetAll()
        {
            var dbProblems = _context.Problems.ToList();
            List<ProblemDto> problemDtos = new List<ProblemDto>();

            foreach (var dbProblem in dbProblems)
            {
                var problem = ExtractProblem(dbProblem.JsonObject);
                var dto = ProblemConverter.ToDto(problem);
                dto.Id = dbProblem.Id;

                problemDtos.Add(dto);
            }

            return problemDtos;
        }

        public void SaveChanges(Problem problem)
        {
            _context.SaveChanges();
        }


        public object GetToursProblems(long tourId)
        {
            var dbProblems = GetAll();
            List<ProblemDto> problemDtos = new List<ProblemDto>();

            foreach (var dbProblem in dbProblems)
            {
                if(tourId == dbProblem.TourId)
                {
                    problemDtos.Add(dbProblem);
                }
            }

            return problemDtos;
        }
    


        public TourDto TourFromProblem(ProblemDto problem)
        {
            var associatedTour = _context.Tours.FirstOrDefault(t => t.Id == problem.TourId);

            if (associatedTour != null)
            {
                var tourDto = JsonConvert.DeserializeObject<TourDto>(associatedTour.JsonObject);
                // Ako je potrebno dodatno mapiranje ili manipulacija podacima, obavite to ovde

                _context.Tours.Remove(associatedTour);
                _context.SaveChanges();

                return tourDto;
            }

            return null; // Vrati null ukoliko tura nije pronađena
        }



    }
}

