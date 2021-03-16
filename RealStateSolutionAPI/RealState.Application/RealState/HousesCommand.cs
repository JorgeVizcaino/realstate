using MediatR;
using Microsoft.EntityFrameworkCore;
using RealState.Application.common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealState.Application.RealState
{
    public class HousesCommand
    {
        public class Command : IRequest<List<HousesModel>>
        {
            public int IdForm { get; set; }
            public string AnswerJson { get; set; }
            public string IdUser { get; set; }
            public int AnswerType { get; set; }
            public string CreatedBy { get; set; }
        }

        public sealed class HousesHandler : IRequestHandler<Command, List<HousesModel>>
        {
            private readonly IApplicationDbContext _dbContext;

            public HousesHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<List<HousesModel>> Handle(Command request, CancellationToken cancellationToken)
            {
                var resp = await _dbContext.Property
                        .AsNoTracking()
                        .Include(x => x.address)
                        .Include(x => x.physical)
                        .Include(x => x.financial)                        
                        .Select(x => new HousesModel
                        {
                            Address = x.address.address1,
                            Year = x.physical.yearBuilt,
                            ListPrice = x.financial.listPrice,
                            MonthlyRent = x.financial.monthlyRent,
                            GrossYield = ((x.financial.monthlyRent * 12) / x.financial.listPrice)
                        }).ToListAsync(cancellationToken);

                return resp;              
            }
        }
    }
}
