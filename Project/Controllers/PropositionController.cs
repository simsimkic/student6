// File:    QuestionController.cs
// Created: Monday, May 4, 2020 8:43:25 PM
// Purpose: Definition of Class QuestionController

using System;
using System.Collections.Generic;
using Project.Controllers;
using Project.Model;
using Project.Services;
using Project.Views.Converters;
using Project.Views.Model;

namespace Controller
{
    public class PropositionController : IController<PropositionDTO, long>
    {
        private IPropositionService _service;
        private IConverter<Proposition, PropositionDTO> _propositionConverter;


        public PropositionController(
            IPropositionService service,
            IConverter<Proposition, PropositionDTO> propositionConverter
            )
        {
            _service = service;
            _propositionConverter = propositionConverter;
        }

        public PropositionDTO GetById(long id) 
            => _propositionConverter.ConvertEntityToDTO(_service.GetById(id));

        public IEnumerable<PropositionDTO> GetAll() 
            => _propositionConverter.ConvertListEntityToListDTO((List<Proposition>)_service.GetAll());

        public PropositionDTO Remove(PropositionDTO entity) 
            => _propositionConverter.ConvertEntityToDTO(_service.Remove(_propositionConverter.ConvertDTOToEntity(entity)));

        public PropositionDTO Save(PropositionDTO entity) 
            => _propositionConverter.ConvertEntityToDTO(_service.Save(_propositionConverter.ConvertDTOToEntity(entity)));

        public PropositionDTO Update(PropositionDTO entity) 
            => _propositionConverter.ConvertEntityToDTO(_service.Update(_propositionConverter.ConvertDTOToEntity(entity)));

        public PropositionDTO Approve(PropositionDTO entity)
            => _propositionConverter.ConvertEntityToDTO(_service.Approve(_propositionConverter.ConvertDTOToEntity(entity)));

        public PropositionDTO Reject(PropositionDTO entity)
            => _propositionConverter.ConvertEntityToDTO(_service.Reject(_propositionConverter.ConvertDTOToEntity(entity)));
    }
}