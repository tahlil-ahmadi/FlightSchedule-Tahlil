using System.Collections.Generic;
using System.Data;
using FlightSchedule.Application.Contracts;
using FlightSchedule.Application.Contracts.DataTransferObjects;
using FlightSchedule.Application.Mappers;
using FlightSchedule.Domain.Model;
using FlightSchedule.Domain.Services;
using Mapster;

namespace FlightSchedule.Application
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _repository;
        private readonly IFlightCalculationService _calculationService;

        public FlightService(IFlightRepository repository, IFlightCalculationService calculationService)
        {
            _repository = repository;
            _calculationService = calculationService;
        }

        public void GenerateFlights(ReserveScheduleDto reserveScheduleDto)
        {
            var schedule = Mapper.MapReserveScheduleDto(reserveScheduleDto);
            var flights = _calculationService.Calculate(schedule);
            foreach (var flight in flights)
            {
                _repository.Save(flight);
            }
        }

        public List<FlightDto> GetFlightsByNumber(string flightNumber)
        {
            var flights = _repository.GetByFlightNumber(flightNumber.Trim());
            return flights.Adapt<List<FlightDto>>();
        }
    }
}