using AutoMapper;
using MovieManagement.DataAccess.Implementaions;
using MovieManagement.Domain.Dtos.ReqDtos;
using MovieManagement.Domain.Dtos.ResDtos;
using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess.Service.ActorService
{
    public class ActorService : IActorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ActorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void AddActor(ActorReqDto actorReqDto)
        {
            try
            {
                var actor = _mapper.Map<Actor>(actorReqDto);
                _unitOfWork.Actor.Add(actor);
                _unitOfWork.Save();
            }
            catch { }
        }

        public IEnumerable<ActorResDto> GetAll()
        {
            var actors = _unitOfWork.Actor.GetAll();
            var actorsDto = _mapper.Map<List<ActorResDto>>(actors);
            return actorsDto;
        }

        public ActorResDto GetById(int id)
        {
            var actor = _unitOfWork.Actor.GetById(id);
            if (actor == null)
            {
                throw new NotFoundException("Invalid Actor Id");
            }
            var actorsDto = _mapper.Map<ActorResDto>(actor);
            return actorsDto;
        }

        public void UpdateActor(int id, ActorReqDto actorUpdateRequest)
        {
            var actor = _unitOfWork.Actor.GetById(id);
            if (actor == null)
            {
                throw new NotFoundException("Actor not found");
            }
            actor.FirstName = actorUpdateRequest.FirstName;
            actor.LastName = actorUpdateRequest.LastName;

            _unitOfWork.Actor.Update(actor);
            _unitOfWork.Save();
        }
    }
}
