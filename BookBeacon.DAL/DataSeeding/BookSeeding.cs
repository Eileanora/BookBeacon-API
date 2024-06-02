using BookBeacon.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BookBeacon.DAL.DataSeeding;

public class BookSeeding
{
public static void SeedBooks(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Book>().HasData(
        new Book // 1
        {
            Id = 1,
            Title = "Children of Gebelawi",
            PageCount = 355,
            ISBN = "9780894106548",
            Edition = 1,
            PublicationDate = new DateTime(1959, 1, 1),
            Summary = "A novel by Naguib Mahfouz, depicting the patriarchal figure Gebelaawi and his children, average Egyptians living the lives of Cain and Abel, Moses, and Jesus.",
            PublisherId = 1,
            AuthorId = 1,
            CategoryId = 2,
        },
        new Book // 2
        {
            Id = 2,
            Title = "The Thief and the Dogs",
            PageCount = 160,
            ISBN = "9780385264624",
            Edition = 1,
            PublicationDate = new DateTime(1961, 1, 1),
            Summary = "Naguib Mahfouz's haunting novel about post-revolutionary Egypt.",
            PublisherId = 1,
            AuthorId = 1,
            CategoryId = 2,
        },
        new Book // 3
        {
            Id = 3,
            Title = "Woman at Point Zero",
            PageCount = 128,
            ISBN = "9780894108573",
            Edition = 2,
            PublicationDate = new DateTime(1975, 1, 1),
            Summary = "A powerful Egyptian novel relayed by Nawal El Saadawi about a woman rebelling against a society founded on lies, cruelty, and corruption.",
            PublisherId = 6,
            AuthorId = 4,
            CategoryId = 2,
        },
        new Book // 4
        {
            Id = 4,
            Title = "The Hidden Face of Eve",
            PageCount = 255,
            ISBN = "9781842778753",
            Edition = 1,
            PublicationDate = new DateTime(1977, 1, 1),
            Summary = "Nawal El Saadawi writes out of a powerful sense of the violence and injustice which permeated her society. Her experiences working as a doctor in villages around Egypt, witnessing prostitution, honour killings and sexual abuse, including female circumcision, drove her to give voice to this suffering.",
            PublisherId = 6,
            AuthorId = 4,
            CategoryId = 6,
        },
        new Book // 5
        {
            Id = 5,
            Title = "The Days",
            PageCount = 368,
            ISBN = "9789774240260",
            Edition = 1,
            PublicationDate = new DateTime(1927, 1, 1),
            Summary = "Taha Hussein's autobiography is an enlightening at personal and social levels, and includes his experiences from village life to intellectual circles.",
            PublisherId = 2,
            AuthorId = 2,
            CategoryId = 7,
        },
        new Book // 6
        {
            Id = 6,
            Title = "The Call of the Curlew",
            PageCount = 200,
            ISBN = "9789774245548",
            Edition = 1,
            PublicationDate = new DateTime(1934, 1, 1),
            Summary = "A novel by Taha Hussein that is a social and political commentary on the times in Egypt.",
            PublisherId = 2,
            AuthorId = 2,
            CategoryId = 2,
        },
        new Book // 7
        {
            Id = 7,
            Title = "The Map of Love",
            PageCount = 529,
            ISBN = "9780385720113",
            Edition = 1,
            PublicationDate = new DateTime(1999, 1, 1),
            Summary = "Ahdaf Soueif weaves an account of love and loss, of change and resistance, a moving and deeply absorbing story of modern Egypt.",
            PublisherId = 3,
            AuthorId = 3,
            CategoryId = 2,
        }
    );
}

}
