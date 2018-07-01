﻿using System.Linq;
using PercentageCalculator.Models.Response;

namespace PercentageCalculator.Logic
{
    public class RequestHandler
    {
        public Root Execute(Models.Request.Root input)
        {
            var valueSum = input.Data.Sum(x => x.Value);

            var rawPercentages = input.Data.Select(x => (decimal) x.Value / valueSum * 100).ToList();

            var roundedPercentages = new PercentageRounder().Execute(rawPercentages);
            var response = new Root();
            for (var i = 0; i < roundedPercentages.Count; i++)
            {
                var responseData = new Data
                                   {
                                           Percentage = roundedPercentages[i],
                                           Text = input.Data[i].Text,
                                           Value = input.Data[i].Value
                                   };
                response.Data.Add(responseData);
            }

            return response;
        }
    }
}