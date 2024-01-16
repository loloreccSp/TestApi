
using Microsoft.EntityFrameworkCore;
using TestApiMovie.Data.Context;
using TestApiMovie.Data.Entites;

namespace TestApiMovie.Service.Commands.Delete
{
    public class DeleteCategoryCommand
    {
        public int CategoryIdDel { get; set; }

    }

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly TestApiMovieContext _context;
        
        public DeleteCategoryCommandHandler(TestApiMovieContext context) => _context = context;

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken = default)
        {
            var category = await GetCategoryAsync(request.CategoryIdDel, cancellationToken);

            if (category != null)
            {
                _context.Categorys.Remove(category);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }

        private async Task<Category> GetCategoryAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Categorys.SingleOrDefaultAsync(c => c.CategoryId == id, cancellationToken);
        }
    }
}
