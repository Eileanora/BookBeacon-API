using BookBeacon.BL.Repositories;
using BookBeacon.BL.ResourceParameters;
using BookBeacon.DAL.Context;
using BookBeacon.DAL.Helpers.SortHelper;
using BookBeacon.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BookBeacon.DAL.Repositories;

internal class BookRepository : BaseRepository<Book>, IBookRepository
{
    private readonly ISortHelper<Book> _sortHelper;
    public BookRepository(
        BookBeaconContext context,
        ISortHelper<Book> sortHelper) : base(context)
    {
        _sortHelper = sortHelper;
    }
    
    public async Task<PagedList<Book>> GetAllAsync(BookResourceParameters resourceParameters)
    {
        var collection = DbContext.Books as IQueryable<Book>;

        collection = collection
            .AsNoTracking()
            .Include(b => b.Author)
            .Include(b => b.Publisher)
            .Include(b => b.Category)
            .Include(b => b.Genres)
            .Include(b => b.Copies);
        
        if (!string.IsNullOrWhiteSpace(resourceParameters.SearchQuery))
        {
            var searchQuery = resourceParameters.SearchQuery.Trim();
            collection = collection.Where(b =>
                b.Title.Contains(searchQuery) ||
                b.ISBN.Contains(searchQuery));
        }
        
        collection = ApplyFiltering(collection, resourceParameters);
        
        var sortedList = _sortHelper.ApplySort(collection, resourceParameters.OrderBy);
        
        return await CreateAsync(
            sortedList,
            resourceParameters.PageNumber,
            resourceParameters.PageSize);
    }
    
    public async Task<IEnumerable<Language?>?> GetLanguagesForBookAsync(int bookId)
    {
        var book = await DbContext.Books
            .FindAsync(bookId);

        if (book == null)
            return null;
        
        await DbContext.Entry(book)
            .Collection(b => b.Copies)
            .Query()
            .Include(c => c.Language)
            .LoadAsync();
        
        return book.Copies.Select(c => c.Language).Distinct();
    }

    private IQueryable<Book> ApplyFiltering(
        IQueryable<Book> collection, BookResourceParameters resourceParameters)
    {
        if (!string.IsNullOrWhiteSpace(resourceParameters.Author))
        {
            var author = resourceParameters.Author.Trim();
            var splitAuthor = author.Split(' ');
            collection = collection.Where(b =>
                b.Author.FirstName.Contains(splitAuthor[0]) ||
                b.Author.LastName.Contains(splitAuthor[1]));
        }
        
        if (!string.IsNullOrWhiteSpace(resourceParameters.Publisher))
        {
            var publisher = resourceParameters.Publisher.Trim();
            collection = collection.Where(b =>
                b.Publisher.Name.Contains(publisher));
        }
        
        if (!string.IsNullOrWhiteSpace(resourceParameters.Category))
        {
            var category = resourceParameters.Category.Trim();
            collection = collection.Where(b =>
                b.Category.Name.Contains(category));
        }
        
        if (!string.IsNullOrWhiteSpace(resourceParameters.Genre))
        {
            var genre = resourceParameters.Genre.Trim();
            collection = collection.Where(b =>
                b.Genres.Any(g => g.Name.Contains(genre)));
        }
        
        if (!string.IsNullOrWhiteSpace(resourceParameters.Language))
        {
            var language = resourceParameters.Language.Trim();
            collection = collection.Where(b =>
                b.Copies.Any(c => c.Language.Name.Contains(language)));
        }
        
        return collection;
    }

    public Task<Book?> GetByIdAsync(int? id)
    {
        return DbContext.Books
            .AsNoTracking()
            .Include(b => b.Author)
            .Include(b => b.Publisher)
            .Include(b => b.Category)
            .Include(b => b.Genres)
            .Include(b => b.Copies)
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<bool> IsIsbnUnique(string title)
    {
        return await DbContext.Books
            .AsNoTracking()
            .AnyAsync(b => b.Title == title);
    }

    public async Task<bool> BookExistsAsync(int? id)
    {
        if (id == null)
            return false;
        return await DbContext.Books
            .AsNoTracking()
            .AnyAsync(b => b.Id == id);
    }
}
