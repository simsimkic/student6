using Project.Model;
using Project.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    class ReviewService: IService<Review,long>
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public IEnumerable<Review> GetAll()
          => _reviewRepository.GetAll();

        public Review GetById(long id)
        => _reviewRepository.GetById(id);

        public Review Remove(Review entity)
        => _reviewRepository.Remove(entity);

        public Review Save(Review entity)
        => _reviewRepository.Save(entity);

        public Review Update(Review entity)
        => _reviewRepository.Update(entity);
    }
}
