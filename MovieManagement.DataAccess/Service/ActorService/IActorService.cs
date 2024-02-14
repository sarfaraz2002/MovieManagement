using Microsoft.EntityFrameworkCore.Migrations.Operations;
using MovieManagement.Domain.Dtos.ReqDtos;
using MovieManagement.Domain.Dtos.ResDtos;
using MovieManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess.Service.ActorService
{
    public interface IActorService
    {
        IEnumerable<ActorResDto> GetAll();
        void AddActor(ActorReqDto actorReqDto);
        void UpdateActor(int id, ActorReqDto actorUpdateRequest);
        ActorResDto GetById(int id);

    }
}
