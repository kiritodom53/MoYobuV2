using Xamarin.Forms;

namespace MoYobuV2.Models
{
    public class Manga
    {
        public string Title { get; set; }
        public ImageSource Image { get; set; }

        public Manga(string title, ImageSource image)
        {
            Title = title;
            Image = image;
        }
    }
}