using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSchedule.Application.Contracts.DataTransferObjects;
using RestSharp;

namespace FlightSchedule.Specs.Endpoints
{
    public static class FlightEndpoint
    {
        public static void GenerateFlights(ReserveScheduleDto schedule)
        {
            var client = new RestClient("http://localhost:5783/api/");

            var request = new RestRequest("flights", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddJsonBody(schedule);
            var response = client.Execute(request);
        }

        public static List<FlightDto> GetByFlightNumber(string flightNumber)
        {
            var client = new RestClient("http://localhost:5783/api/");
            var request = new RestRequest("flights", Method.GET);
            request.AddQueryParameter("flightNumber", flightNumber);
            var response= client.Execute<List<FlightDto>>(request);
            return response.Data;
        }
    }
}
