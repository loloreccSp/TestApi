
//using Microsoft.EntityFrameworkCore;
//using TestApiMovie.Data.Context;
//using TestApiMovie.Data.Entites;

//namespace TestApiMovie.Service.Commands.Put
//{
//    public class PutCategoryCommand
//    {
//        public int CategoryIdPut { get; set; }
//        //public string CategoryName { get; set; }
//        //public string CategoryDescription { get; set; }
//    }

//    public class PutCategoryCommandHandler : IRequestHandler<PutCategoryCommand, Category>
//    {
//        private readonly TestApiMovieContext _context;
        
//        public PutCategoryCommandHandler(TestApiMovieContext context) => _context = context;

//        public async Task<Category> Handle(PutCategoryCommand request, CancellationToken cancellationToken = default)
//        {
//            var category = await GetCategoryAsync(request.CategoryIdPut, cancellationToken);

//            if (category != null) //category.CategoryId == request.CategoryIdPut
//            {
//                 _context.Categorys.Update(category);
//                await _context.SaveChangesAsync(cancellationToken);

//                //return category;
//                //return new Category
//                //{
//                //    CategoryId = category.CategoryId,
//                //    CategoryName = category.CategoryName,
//                //    CategoryDescription = category.CategoryDescription
//                //};
//            }
//            return category;
//            //return new Category
//            //{
//            //    CategoryId = 0
//            //};
//        }

//        private async Task<Category> GetCategoryAsync(int id, CancellationToken cancellationToken)
//        {
//            return await _context.Categorys.SingleOrDefaultAsync(c => c.CategoryId == id, cancellationToken);
//        }
//    }
//}
