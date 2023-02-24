// File:    ReviewController.cs
// Created: Tuesday, May 5, 2020 10:20:54 PM
// Purpose: Definition of Class ReviewController

using Project.Controllers;
using Project.Model;
using Project.Services;
using Project.Views.Converters;
using Project.Views.Model;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class ReviewController : IController<ReviewDTO,long>
   {
        private IService<Review, long> _service;
        private IConverter<Review, ReviewDTO> _reviewConverter;

        public ReviewController(
           IService<Review, long> service,
           IConverter<Review, ReviewDTO> reviewConverter
           )
        {
            _service = service;
            _reviewConverter = reviewConverter;
        }

        public IEnumerable<ReviewDTO> GetAll()
            => _reviewConverter.ConvertListEntityToListDTO((List<Review>)_service.GetAll());

        public ReviewDTO GetById(long id)
            => _reviewConverter.ConvertEntityToDTO(_service.GetById(id));

        public ReviewDTO Remove(ReviewDTO entity)
            => _reviewConverter.ConvertEntityToDTO(_service.Remove(_reviewConverter.ConvertDTOToEntity(entity)));

        public ReviewDTO Save(ReviewDTO entity)
           => _reviewConverter.ConvertEntityToDTO(_service.Save(_reviewConverter.ConvertDTOToEntity(entity)));

        public ReviewDTO Update(ReviewDTO entity)
           => _reviewConverter.ConvertEntityToDTO(_service.Update(_reviewConverter.ConvertDTOToEntity(entity)));
    }
}