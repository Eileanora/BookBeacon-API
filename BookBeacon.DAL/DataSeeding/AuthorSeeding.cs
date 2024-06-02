using BookBeacon.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BookBeacon.DAL.DataSeeding;

public class AuthorSeeding
{
    public static void SeedAuthors(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>().HasData(
            new Author // 1
            {
                Id = 1,
                FirstName = "Naguib",
                LastName = "Mahfouz",
                Biography =
                    "Naguib Mahfouz was an Egyptian writer who won the 1988 Nobel Prize for Literature. He is regarded as one of the first contemporary writers of Arabic literature, along with Tawfiq el-Hakim, to explore themes of existentialism. He published 34 novels, over 350 short stories, dozens of movie scripts, and five plays over a 70-year career. Many of his works have been made into Egyptian and foreign films.",
            },
            new Author // 2
            {
                Id = 2,
                FirstName = "Taha",
                LastName = "Hussein",
                Biography = "Taha Hussein was a prominent Egyptian writer and intellectual, and one of the most influential 20th-century Egyptian classical intellectuals. He wrote novels, short stories, and autobiographies, among other genres."
            },
            new Author // 3
            {
                Id = 3,
                FirstName = "Ahdaf",
                LastName = "Soueif",
                Biography = "Ahdaf Soueif is a contemporary Egyptian writer and political campaigner. She is known for her novel 'The Map of Love'."
            },
            new Author // 4
            {
                Id = 4,
                FirstName = "Nawal",
                LastName = "El-Saadawi",
                Biography = "Nawal El Saadawi was a popular female writer from Egypt. She was also a physician, psychiatrist, and activist. She was one of the most powerful leaders who advocated for the rights of women not only in Egypt but also throughout the Arab world."
            },
            new Author // 5
            {
                Id = 5,
                FirstName = "Yusuf",
                LastName = "Idris",
                Biography = "Yusuf Idris was one of the most popular Egyptian writers of all time. During his prolific career, he wrote novels, plays, and even a short story or two[^2^][2]."
            },
            new Author // 6
            {
                Id = 6,
                FirstName = "Tawfiq",
                LastName = "al-Hakim",
                Biography = "Tawfiq al-Hakim was a pioneering figure in modern Arabic literature. He was a versatile writer who wrote in many different genres[^1^][1]."
            },
            new Author // 7
            {
                Id = 7,
                FirstName = "Youssef",
                LastName = "Ziedan",
                Biography = "Youssef Ziedan is a contemporary Egyptian author known for his contributions to Arabic literature[^2^][4]."
            },
            new Author // 8
            {
                Id = 8,
                FirstName = "Said",
                LastName = "Noah",
                Biography = "Said Noah is a recognized Egyptian writer who has made significant contributions to Egyptian literature."
            },
            new Author // 9
            {
                Id = 9,
                FirstName = "Samir",
                LastName = "El-Manzalawi",
                Biography = "Samir El-Manzalawi is an Egyptian writer who has been honored for his work in the field of literature."
            },
            new Author // 10
            {
                Id = 10,
                FirstName = "Mustafa",
                LastName = "Nasr",
                Biography = "Mustafa Nasr is a respected writer from Egypt who has made a name for himself in the literary world."
            }

        );
    }
}