using Microsoft.AspNetCore.Http;
using Ocelot.Middleware;
using Ocelot.Multiplexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mkt.Gateway.Aggregators
{
    public class CatalogAggregator : IDefinedAggregator
    {
        public Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            throw new NotImplementedException();
        }
    }
}
